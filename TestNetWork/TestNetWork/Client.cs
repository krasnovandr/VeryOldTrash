using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using ClassesForSerialize;
using System.Threading;
using System.Windows.Forms;

namespace TestNetWork
{
    public static class IpPort
    {
        public static int port = 5000;
        public static int recievePort;
        public static String IP = "192.168.1.5";
    }

    public delegate void MyDelegate(string message);

    public class Client
    {
        public SomeText PlayerInfo { get; set; }
        public List<SomeText> PlayersListInfo { get; set; }
        public Thread RecieveThread { get; set; }
        public int TimeTick { get; set; }

        MyDelegate delege;

        public Client(MyDelegate delege)
        {
            this.delege = delege;
        }

        public void recievePlayersListInfo()
        {
            while (true)
            {
                // MessageBox.Show("1");
                PlayersListInfo = (List<SomeText>)Sockets.recieveUDPMeassage();
                // MessageBox.Show("2");
                string message = "Players Count:" + PlayersListInfo.Count + 
                                  "MyPort"+IpPort.recievePort + Environment.NewLine;
                //MessageBox.Show(PlayersListInfo[0].message.ToString());
                for (int i = 0; i < PlayersListInfo.Count; i++)
                {
                    message += "[Player name:" +PlayersListInfo[i].message.ToString() +
                        PlayersListInfo[i].year.ToString()  +"]"+ Environment.NewLine;
                }
                this.delege(message);
            }
        }
        public void startGameSession()
        {
            SomeText sendTCPPacket = new SomeText();
            SomeText recieveTCPPacket = new SomeText();
            sendTCPPacket.message = "Kalter";

            Sockets.connectTCP();
            Sockets.sendTCPMeassage(sendTCPPacket);

            recieveTCPPacket = (SomeText)Sockets.recieveTCPMeassage();


            switch (recieveTCPPacket.message)
            {
                case "Go":
                    //MessageBox.Show("Ну что можно начинать игру");
                    IpPort.recievePort = recieveTCPPacket.year;
                    Sockets.connectUDPRecieve();
                    RecieveThread = new Thread(recievePlayersListInfo);
                    RecieveThread.Start();

                    while (true)
                    {
                        Random rnd = new Random();
                        PlayerInfo = new SomeText();
                        PlayerInfo.year = rnd.Next(0, 100);
                        PlayerInfo.message = "Kalter";
                        PlayerInfo.pi = IpPort.recievePort;
                        Sockets.sendUDPMeassage(PlayerInfo);
                        Thread.Sleep(1000);
                    }
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }




    }
}
