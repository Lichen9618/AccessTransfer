using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Lib.DataTransfer;

namespace AccessTransferServer
{
    public partial class Receiver : Form
    {
        public Server server;
        public Receiver()
        {
            server = new Server("127.0.0.1", 8888);
            var timer = new System.Timers.Timer();
            InitializeComponent();

            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(FreshMessage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.SetConnect();
            server.SetReceiveMessage();
            if (server.connect && server.receiveMessage)
            {
                richTextBox.AppendText("开始监听:" + "\r\n");
                server.Start();
            }
            else 
            {
                richTextBox.AppendText("结束监听:" + "\r\n");
            }
        }

        private void FreshMessage(object source, ElapsedEventArgs e) 
        {
            string text = server.ShowMessage();
            if (text != "") 
            {
                richTextBox.AppendText("\r\n" + text);
            }
        }


    }
}
