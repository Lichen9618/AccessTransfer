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
            server = new Server(System.Windows.Forms.Application.ExecutablePath);
            timer = new System.Timers.Timer();
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(this.Close);
            if (server.sqlServerConnection.IsConnected) 
            {
                labelDataBaseConnection.Text = "数据库已连接";
            }
            timer.Enabled = true;
            timer.Interval = 2000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(FreshMessage);
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.SetConnect();
            server.SetReceiveMessage();
            if (server.connect && server.receiveMessage)
            {
                richTextBox.AppendText("\r\n" + "开始监听:" + "\r\n");
                server.Start();
            }
            else
            {
                richTextBox.AppendText("\r\n" + "结束监听:" + "\r\n");
            }
        }

        private void FreshMessage(object source, ElapsedEventArgs e)
        {
            string text = server.ShowMessage();
            if (text != "")
            {
                richTextBox.AppendText("\r\n" + text);
            }
            richTextBoxConnectionPool.Text = server.CheckConnection();
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                server.Stop();
                timer.Stop();
                e.Cancel = false;

            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void buttonDataBaseConfig_Click(object sender, EventArgs e)
        {
            SqlServerConfig sqlServerConfig = new SqlServerConfig(System.Windows.Forms.Application.ExecutablePath);
            sqlServerConfig.Show();
            sqlServerConfig.FormClosed += DataBaseConnectionReminder;
        }

        private void DataBaseConnectionReminder(object sender, EventArgs e)
        {
            labelDataBaseConnection.Text = "数据库已连接";
        }
    }
}
