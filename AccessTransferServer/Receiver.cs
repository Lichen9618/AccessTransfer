using Lib.DataTransfer;
using System;
using System.Timers;
using System.Windows.Forms;

namespace AccessTransferServer
{
    public partial class Receiver : Form
    {
        public Server server;
        System.Timers.Timer timer;
        public Receiver()
        {
            server = new Server();
            timer = new System.Timers.Timer();
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(this.Close);

            timer.Enabled = true;
            timer.Interval = 500;
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
            string connectionText;
            if (server.ShowConnectionMessage(out connectionText)) 
            {
                richTextBox.AppendText("\r\n" + connectionText);
            }
            if (text != "")
            {
                richTextBox.AppendText("\r\n" + text);
            }
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                timer.Stop();
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

    }
}
