using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Server.Models;
using Server.Others;

namespace Server.Controllers
{

    public enum DeviceType { Signalization = 1, Door, Conditioner, Sensor }
    public enum Days { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
    public static class IpPort
    {
        public static string ip = "127.0.0.1";
        public static int port = 2200;
    }
    public static class Times
    {
        public static int year = 1;
        public static int month = 1;
        public static int sec = 0;
    }
    public class HomeController : Controller
    {
        //
        // GET: /Home/


        public ActionResult Index()
        {

            using (var context = new DevicesEntities())
            {
                var result = (from ent in context.Device
                              where ent.UserName == User.Identity.Name
                              select ent).ToList();
                ViewBag.modelka = result;

                MemoryStream stream1 = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Device>));
                ser.WriteObject(stream1, result);
                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);


                ViewBag.jsonSer = sr.ReadToEnd();

                List<Sensor> listSensor = new List<Sensor>();

                var sen = (from ent1 in context.Sensor
                           //where ent1.DeviceSerial == result[i].DeviceSerial
                           select ent1).ToList();

                for (int i = 0; i < sen.Count; i++)
                {
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (sen[i].DeviceSerial == result[j].DeviceSerial)
                        {
                            listSensor.Add(sen[i]);
                        }
                    }
                }

                ViewBag.listSensor = listSensor;

                return View(result);
            }
        }
        public ActionResult CreateShedule(int DeviceSerial)
        {
            Time time = new Time();
            time.DeviceSerial = DeviceSerial;
            
            return View(time);
        }
        [HttpPost]
        public ActionResult CreateShedule(Time time)
        {

            using (var context = new DevicesEntities())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        context.Time.Add(time);
                        context.SaveChanges();
                        return RedirectToAction("Schedule", new { DeviceSerial = time.DeviceSerial });
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex);
                }
                return View(time);
            }
        }

        public ActionResult DeleteShedule(int id)
        {
            using (var context = new DevicesEntities())
            {
                var employeeDelete = (from entity in context.Time
                                      where entity.Id == id
                                      select entity).First();
                return View(employeeDelete);
            }
        }


        [HttpPost]
        public ActionResult DeleteShedule(int id, FormCollection collection)
        {

            using (var context = new DevicesEntities())
            {
                var employeeDelete = (from entity in context.Time
                                      where entity.Id == id
                                      select entity).First();
                try
                {
                    context.Time.Attach(employeeDelete);
                    context.Time.Remove(employeeDelete);
                    context.SaveChanges();
                    return RedirectToAction("Schedule", new { DeviceSerial = employeeDelete.DeviceSerial });
                }
                catch
                {
                    return View(employeeDelete);
                }
            }
        }
        public ActionResult Schedule(int DeviceSerial)
        {

            using (var context = new DevicesEntities())
            {
                var device = (from entity in context.Device
                              where entity.DeviceSerial == DeviceSerial
                              select entity).First();

                ViewBag.DeviceSerial = device.DeviceSerial;

                var deviceTimes = (from entity in context.Time
                                   where entity.DeviceSerial == device.DeviceSerial
                                   select entity).ToList();
                return View(deviceTimes);
            }

        }


        public ActionResult TconstSet(int DeviceSerial)
        {

            using (var context = new DevicesEntities())
            {
                var sensor = (from entity in context.Sensor
                              where entity.DeviceSerial == DeviceSerial
                              select entity).First();

                return View(sensor);
            }
        }

        [HttpPost]
        public ActionResult TconstSet(Sensor model)
        {
            using (var context = new DevicesEntities())
            {

                var device = (from entity in context.Sensor
                              where entity.DeviceSerial == model.DeviceSerial
                              select entity).First();

                device.tconst = model.tconst;

                UpdateModel(device);
                context.SaveChanges();
                TcpClient Client = new TcpClient();
                Client.Connect(IPAddress.Parse(IpPort.ip), IpPort.port);

                Socket Sock = Client.Client;
                Sock.Send(MySerialize.serialize(device, typeof(Sensor)));

                Sock.Close();
                Client.Close();
            }

            return RedirectToAction("Index", "Home");
        }


        public ActionResult AddEmptyToYour(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                var result = (from ent in context.Device
                              where ent.DeviceSerial == DeviceSerial
                              select ent).First();
                result.UserName = User.Identity.Name;
                UpdateModel(result);
                context.SaveChanges();
                return RedirectToAction("emptyDevices");
            }
        }
        public ActionResult emptyDevices()
        {
            using (var context = new DevicesEntities())
            {
                var result = (from ent in context.Device
                              where ent.UserName == "Empty"
                              select ent).ToList();

                return View(result);
            }
        }

        public ActionResult setDeviceOnMap(int DeviceSerial)
        {
            ViewBag.serial = DeviceSerial;
            return View();
        }
        [HttpPost]
        public ActionResult setDeviceOnMap(int DeviceSerial, string lat, string lng)
        {
            using (var context = new DevicesEntities())
            {
                var result = (from ent in context.Device
                              where ent.DeviceSerial == DeviceSerial
                              select ent).First();

                result.mapX = lat;
                result.mapY = lng;
                result.UserName = User.Identity.Name;
                UpdateModel(result);
                context.SaveChanges();
                return RedirectToAction("emptyDevices");

            }
        }

        public ActionResult TurnOnOff(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                var device = (from entity in context.Device
                              where entity.DeviceSerial == DeviceSerial
                              select entity).First();
                if (device.State == 0)
                {
                    device.State = 1;
                }
                else
                {
                    device.State = 0;
                }
                UpdateModel(device);
                context.SaveChanges();
                TcpClient Client = new TcpClient();
                Client.Connect(IPAddress.Parse(IpPort.ip), IpPort.port);

                Socket Sock = Client.Client;
                Sock.Send(MySerialize.serialize(device, typeof(Device)));

                Sock.Close();
                Client.Close();

                return RedirectToAction("Index", "Home");
            }


        }
        public ActionResult setTiming(int DeviceSerial)
        {

            using (var context = new DevicesEntities())
            {
                var device = (from entity in context.Device
                              where entity.DeviceSerial == DeviceSerial
                              select entity).First();

                var times = (from entity in context.Time
                             where entity.DeviceSerial == DeviceSerial
                             select entity).ToList();
                Packet packet = new Packet();
                packet.device = device;
                packet.time = times;

                TcpClient Client = new TcpClient();
                Client.Connect(IPAddress.Parse(IpPort.ip), IpPort.port);

                Socket Sock = Client.Client;
                Sock.Send(MySerialize.serialize(packet, typeof(Packet)));

                Sock.Close();
                Client.Close();

                return RedirectToAction("Index", "Home");
            }

        }

        public int sendTemperature(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                var device = (from entity in context.Sensor
                              where entity.DeviceSerial == DeviceSerial
                              select entity).First();
                return (int)device.temperature;
            }

        }

        public int sendTconst(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                var device = (from entity in context.Sensor
                              where entity.DeviceSerial == DeviceSerial
                              select entity).First();
                return (int)device.tconst;
            }
        }

        public ActionResult ResetAlarm(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                var deviceAlarm = (from entity in context.Alarm
                                   where entity.DeviceSerial == DeviceSerial
                                   select entity).First();

                return View(deviceAlarm);
            }
        }
        public ActionResult ignoreAlarm(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                var deviceAlarm = (from entity in context.Alarm
                                   where entity.DeviceSerial == DeviceSerial
                                   select entity).First();

                context.Alarm.Attach(deviceAlarm);
                context.Alarm.Remove(deviceAlarm);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult ignoreAlarmAndMail(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                var deviceAlarm = (from entity in context.Alarm
                                   where entity.DeviceSerial == DeviceSerial
                                   select entity).First();
                context.Alarm.Attach(deviceAlarm);
                context.Alarm.Remove(deviceAlarm);
                context.SaveChanges();
            }

            var user = Membership.GetUser(User.Identity.Name);

            var email = user.Email;

            var subject = "Some trouble with device " + DeviceSerial;
            var text = "Device " + DeviceSerial + " Alarmed " + Environment.NewLine +
                "This Report is autogenerated";
            MailSender.sendMail(subject, email, text);
          
            return RedirectToAction("Index");

        }



        public string AddDevice(int DeviceSerial, int Type, int State)
        {

            using (var context = new DevicesEntities())
            {

                Device device = new Device();
                device.DeviceSerial = DeviceSerial;
                device.Type = Type;
                device.State = State;
                device.UserName = "Empty";
                try
                {
                    context.Device.Add(device);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                return "Device" + device.DeviceSerial + "Connected";

            }
        }
        public string AddSensor(int DeviceSerial, int Type, int State, int Tconst, int Temp)
        {
            using (var context = new DevicesEntities())
            {

                Device device = new Device();
                device.DeviceSerial = DeviceSerial;
                device.Type = Type;
                device.State = State;
                device.UserName = "Empty";

                Sensor sensor = new Sensor();
                sensor.DeviceSerial = DeviceSerial;
                sensor.tconst = Tconst;
                sensor.temperature = Temp;
                try
                {
                    context.Device.Add(device);
                    context.Sensor.Add(sensor);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                return "Sensor" + device.DeviceSerial + "Connected";

            }
        }
        public string DelDevice(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                var device = (from entity in context.Device
                              where entity.DeviceSerial == DeviceSerial
                              select entity).First();
                try
                {
                    context.Device.Attach(device);
                    context.Device.Remove(device);
                    context.SaveChanges();
                }
                catch
                {
                    return "Error deleting device:" + device.DeviceSerial;
                }
                return "Device deleted" + device.DeviceSerial;
            }
        }




        [HttpGet]
        public string GetState()
        {
            using (var context = new DevicesEntities())
            {
                var result = (from ent in context.Device
                              where ent.UserName == User.Identity.Name
                              select ent).ToList();
                String states = "";
                for (int i = 0; i < result.Count; i++)
                {
                    states += result[i].State.ToString();
                }

                return states;
            }
        }
        [HttpGet]
        public string GetTemperature()
        {
            using (var context = new DevicesEntities())
            {
                var devices = (from entity in context.Sensor
                               select entity).ToList();
                string response = "";
                for (int i = 0; i < devices.Count; i++)
                {
                    response += devices[i].temperature + " ";
                }

                return response;
            }
        }

        

        [HttpGet]
        public string GetAlarm()
        {
            using (var context = new DevicesEntities())
            {
                var result = (from ent in context.Device
                              where ent.UserName == User.Identity.Name
                              select ent).ToList();
                var alarms = (from ent in context.Alarm
                              select ent).ToList();
                string response = "";
                //for (int i = 0; i < result.Count; i++)
                //{
                //    response += "0";
                //}
                for (int i = 0; i < result.Count; i++)
                {
                    bool flg = false;

                    for (int j = 0; j < alarms.Count; j++)
                    {
                        if (result[i].DeviceSerial == alarms[j].DeviceSerial)
                        {
                            flg = true;
                        }
                    }

                    if (flg == true)
                    {
                        response += "1";
                    }
                    else
                    {
                        response += "0";
                    }
                }

                //
                //if (result.Count != 0)
                //{
                //    for (int i = 0; i < result.Count; i++)
                //    {
                //        response += result[i].DeviceSerial;
                //    }

                //}
                return response;
            }
        }
        
        public string sendDevices()
        {
            using (var context = new DevicesEntities())
            {
                var devicesToSend = (from ent in context.Device
                                     select ent).ToList();
                TcpClient Client = new TcpClient();

                Client.Connect(IPAddress.Parse(IpPort.ip), IpPort.port);


                Socket Sock = Client.Client;


                Sock.Send(MySerialize.serialize(devicesToSend, typeof(List<Device>)));

                Sock.Close();
                Client.Close();
                return devicesToSend.Count + "Devices Sended";


            }
        }
        public string AlarmSignalization(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                Alarm alarm = new Alarm();
                alarm.DeviceSerial = DeviceSerial;

                try
                {
                    context.Alarm.Add(alarm);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                return "Signalization" + alarm.DeviceSerial + "Allarmed";
            }
        }
        public string AlarmSensor(int DeviceSerial)
        {
            using (var context = new DevicesEntities())
            {
                Alarm alarm = new Alarm();
                alarm.DeviceSerial = DeviceSerial;

                try
                {
                    context.Alarm.Add(alarm);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                return "Sensor" + alarm.DeviceSerial + "Allarmed";
            }
        }
        public string ChangeState(int DeviceSerial, int state)
        {
            using (var context = new DevicesEntities())
            {
                var device = (from entity in context.Device
                              where entity.DeviceSerial == DeviceSerial
                              select entity).First();


                device.State = state;

                UpdateModel(device);
                context.SaveChanges();
                return "New State is " + device.State;
            }
        }
        public string ChangeTemperature(int DeviceSerial, int temperature)
        {
            using (var context = new DevicesEntities())
            {
                var device = (from entity in context.Sensor
                              where entity.DeviceSerial == DeviceSerial
                              select entity).First();
                device.temperature = temperature;

                UpdateModel(device);
                context.SaveChanges();
                return " New Temperature" + device.temperature;
            }

            //public ActionResult Send()
            //{
            //    return View();
            //}
            //[HttpPost]
            //public ActionResult Send(EmailModel model)
            //{
            // //   if (ModelState.IsValid)
            //  //  {
            //        new EmailController().SendEmail(model).Deliver();
            //    //}
            //    return View(model);
            //}


        }
    }
}
