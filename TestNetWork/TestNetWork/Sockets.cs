using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;

namespace TestNetWork
{
    public static class Sockets
    {
       static Socket socketTCP;
       static Socket socketUDPSend;
       static Socket socketUDPRecieve;
        public static void connectTCP()
        {
            DnsEndPoint remoteEP = new DnsEndPoint(IpPort.IP, IpPort.port);
            
            socketTCP = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socketTCP.Connect(remoteEP);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        public static void sendTCPMeassage(Object message)
        {
            try
            {
                socketTCP.Send(MySerialize.serialize(message));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        public static Object recieveTCPMeassage()
        {
            byte[] bytes = new byte[1500];
            Object obj = null;
            try
            {
                socketTCP.Receive(bytes);
                obj = (Object)MySerialize.deserialize(bytes);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            return obj;
        }




  
        public static void sendUDPMeassage(Object message)
        {
            DnsEndPoint remoteEP = new DnsEndPoint(IpPort.IP, IpPort.port);

            socketUDPSend = new Socket(AddressFamily.InterNetwork,
            SocketType.Dgram, ProtocolType.Udp);
            try
            {
                socketUDPSend.Connect(remoteEP);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            try
            {
                socketUDPSend.Send(MySerialize.serialize(message));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        public static void connectUDPRecieve()
        {
            IPHostEntry ipHostA = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostA.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, IpPort.recievePort);

            socketUDPRecieve = new Socket(AddressFamily.InterNetwork,
            SocketType.Dgram, ProtocolType.Udp);

            socketUDPRecieve.Bind(localEndPoint);
        }


        public static Object recieveUDPMeassage()
        {
          
            byte[] bytes = new byte[1500];
            Object obj = null;
            try
            {

                socketUDPRecieve.Receive(bytes);
                obj = (Object)MySerialize.deserialize(bytes);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            return obj;
        }
    }
}
