using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using ClassesForSerialize;
using System.Threading;
using System.Windows.Forms;
using Gun;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace TestNetWork
{

    public static class IpPort
    {
        public static int port = 5000;
        public static int recievePort;
        public static String IP = "192.168.43.225";
        public static Object locker = new object();
    }

    //public delegate void MyDelegate(string message);

    public class Client
    {
        public GameSession GameSession { get; set; }
        public Thread RecieveThread { get; set; }
        public int TimeTick { get; set; }
        public StringTable stringTable { get; set; }
        // MyDelegate delege;

        public Client()//MyDelegate delege
        {
            GameSession = new GameSession();
            stringTable = new StringTable(new Vector2(20, 50));
            // this.delege = delege;
        }

        public void recievePlayersListInfo()
        {

            while (true)
            {
          
                var recievedPacket = (PacketFromServer)Sockets.recieveUDPMeassage();
                List<Player> players = new List<Player>(); 
                lock (IpPort.locker)
                {
                    stringTable.Clear();
                }
                for (int i = 0; i < recievedPacket.PlayersInfo.Count; i++)
                {
                    Player player = new Player();
                    player.PlayerInfo = recievedPacket.PlayersInfo[i];
                    //
                    players.Add(player);
             
                    lock (IpPort.locker)
                    {
                        stringTable.Add("Players HP:" + Environment.NewLine);
                        stringTable.Add(player.PlayerInfo.HP + Environment.NewLine);
                    }
                }
                GameSession.PlayersList = players;




                List<Bullet> bullets = new List<Bullet>();
                for (int i = 0; i < recievedPacket.BulletInfo.Count; i++)
                {
                    Bullet bullet = new Bullet();
                    bullet.BulletInfo = recievedPacket.BulletInfo[i];

                    bullets.Add(bullet);
                }
                GameSession.BulletsList = bullets;

            }

        }
        public void startGameSession()
        {
            StartPacket sendTCPPacket = new StartPacket();
            StartPacket recieveTCPPacket = new StartPacket();

            sendTCPPacket.username = "Kalter";

            Sockets.connectTCP();
            Sockets.sendTCPMeassage(sendTCPPacket);

            recieveTCPPacket = (StartPacket)Sockets.recieveTCPMeassage();


            switch (recieveTCPPacket.username)
            {
                case "Go":
                    //MessageBox.Show("Ну что можно начинать игру");
                    IpPort.recievePort = recieveTCPPacket.port;
                    Sockets.connectUDPRecieve();
                    RecieveThread = new Thread(recievePlayersListInfo);
                    RecieveThread.Start();

                    while (true)
                    {
                        PacketToServer packetToserver = new ClassesForSerialize.PacketToServer();



                        if (GameSession.Bullet != null)
                        {
                            packetToserver.BulletInfo = GameSession.Bullet.BulletInfo;
                        }

                        Rectangle rectanle = new Rectangle((int)GameSession.Player.PlayerInfo.Position.X,
                                            (int)GameSession.Player.PlayerInfo.Position.Y, GameConstants.playerL.Width, GameConstants.playerR.Height);

                        GameSession.Player.PlayerInfo.Rectangle = rectanle;
                        packetToserver.PlayerInfo = GameSession.Player.PlayerInfo;


                        packetToserver.Port = IpPort.recievePort; ;

                        Sockets.sendUDPMeassage(packetToserver);
                        GameSession.Bullet = null;
                        
                        Thread.Sleep(20);
                    }
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }




    }
}
