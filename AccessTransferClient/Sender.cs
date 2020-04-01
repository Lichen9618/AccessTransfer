using Lib.DataBase;
using Lib.DataBase.Model;
using Lib.DataTransfer;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using System.Configuration;

namespace AccessTransferClient
{
    public partial class Sender : Form
    {
        private Client client;
        private AccessConnection accessConnection;
        System.Timers.Timer timer;
        public Sender()
        {
            InitializeComponent();
            LoadSetting();
            Control.CheckForIllegalCrossThreadCalls = false;
            try
            {
                this.client = Client.GetInstance();
                labelServerConnected.Text = "是";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                labelServerConnected.Text = "否";
            }
            accessConnection = AccessConnection.GetInsantance((System.Windows.Forms.Application.ExecutablePath));
            SetDataBaseConnectionLabel(accessConnection.OpenConnection());
            TimeStart();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (client.ServerConntected)
            {
                client.SetSend();
                if (client.StartToSend == true)
                {
                    if (textBoxInterval.Text != "")
                    {
                        client.SetDataPickInterval(int.Parse(textBoxInterval.Text));
                    }
                    else 
                    {
                        MessageBox.Show("请输入间隔时间");
                        return;
                    }                    
                    client.SetAcceesConnection(accessConnection);
                    GetProcessPattern();
                    client.Start();                    
                    SetTheButton(false);
                    timer.Start();
                    return;
                }
                else 
                {
                    client.End();
                    timer.Stop();
                    SetTheButton(true);
                }
            }
            else 
            {
                client.End();
                timer.Stop();
                SetTheButton(true);
                MessageBox.Show("无法连接至服务端,请检查");
            }
        }

        private void TimeStart()       
        {
            timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 3000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(FreshMessage);
            timer.Start();
        }

        private void FreshMessage(object source, ElapsedEventArgs e)
        {
            List<string> results = client.showMessage();
            if (!(results is null))
            {
                foreach (string item in results)
                {
                    richTextBoxMessage.Text = richTextBoxMessage.Text.Insert(0, "\r\n" + item + "\r\n");
                }
            }
            if (!client.CheckConnection()) 
            {
                labelServerConnected.Text = "否";
                richTextBoxMessage.Text = richTextBoxMessage.Text.Insert(0, "\r\n" + DateTime.Now.ToString() + " 断开连接" + "\r\n");
            }
        }

        private void SetTheButton(bool state) 
        {
            groupBox1.Enabled = state;
            buttonDataBaseChoose.Enabled = state;
            textBoxInterval.Enabled = state;
            buttonConnectToServer.Enabled = state;
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            SaveSetting();
            DialogResult dr = MessageBox.Show("是否退出?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                if (!(client is null)) 
                {
                    if (!(client.accessConnection is null))
                    {
                        client.accessConnection.CloseConnection();
                    }
                    client.End();
                }                
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void buttonDataBaseChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog AccessMDB = new OpenFileDialog();
            AccessMDB.ShowDialog();
            var path = AccessMDB.FileName;
            if (!accessConnection.SetConnection(path))
            {
                MessageBox.Show("数据库路径设置失败");
            }
            SetDataBaseConnectionLabel(accessConnection.OpenConnection());
        }

        private void SetDataBaseConnectionLabel(string dataBasePath) 
        {
            if (dataBasePath != "")
            {
                labelDataBaseName.Text = dataBasePath;
                labelDataBaseConnected.Text = "是";
            }
            else 
            {
                labelDataBaseConnected.Text = "否";
            }
        }

        private void buttonConnectToServer_Click(object sender, EventArgs e)
        {
            if (client.ServerConntected == false)
            {
                MessageBox.Show(client.ConnectServer());
                if (client.ServerConntected == true) 
                {
                    labelServerConnected.Text = "是";
                }
            }
            else 
            {
                MessageBox.Show("已连接服务器,请勿重复连接");
            }
                     
        }

        private ProcessPattern GetProcessPattern() 
        {
            ProcessPattern pattern;
            if (radioButtonMaxValue.Checked)
            {
                pattern = Lib.DataBase.Model.ProcessPattern.Max;
            }
            else if (radioButtonMinValue.Checked)
            {
                pattern = Lib.DataBase.Model.ProcessPattern.Min;
            }
            else if (radioButtonAverage.Checked)
            {
                pattern = Lib.DataBase.Model.ProcessPattern.Average;
            }
            else 
            {
                pattern = Lib.DataBase.Model.ProcessPattern.Latest;
            }
            if (!(client is null)) 
            {
                client.processPattern = pattern;
            }
            return pattern;
        }

        private void SaveSetting() 
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            int PickInterval;
            if (int.TryParse(textBoxInterval.Text,out PickInterval))
            {                
                config.AppSettings.Settings["PickInterval"].Value = (PickInterval).ToString();
            }
            config.AppSettings.Settings["ProcessPattern"].Value = GetProcessPattern().ToString();
            config.Save();
        }

        private void LoadSetting() 
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            textBoxInterval.Text = config.AppSettings.Settings["PickInterval"].Value;
            string pattern = config.AppSettings.Settings["ProcessPattern"].Value;
            if (pattern == "Max")
            {
                radioButtonMaxValue.Checked = true;
            }
            else if (pattern == "Min")
            {
                radioButtonMinValue.Checked = true;
            }
            else if (pattern == "Average")
            {
                radioButtonAverage.Checked = true;
            }
            else if (pattern == "Latest") 
            {
                radioButtonLatest.Checked = true;
            }
        }
    }
}
