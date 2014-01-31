using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace TestNetWork
{
    

    public partial class Form1 : Form
    {
        Client client;
        //MyDelegate del;
        Thread gameThread;
        public Form1()
        {
       
           // del= new MyDelegate(MyHandler);
            //client = new Client(del);
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            gameThread = new Thread(client.startGameSession);
            gameThread.Start();
          
        }
        void MyHandler(string s)
        {
            this.textBox1.Text += s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //gameThread.Abort();
            //client.RecieveThread.Abort();
            //this.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
       
    }
}
