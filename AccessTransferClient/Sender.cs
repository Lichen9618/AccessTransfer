using Lib.DataBase;
using Lib.DataTransfer;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AccessTransferClient
{
    public partial class Sender : Form
    {
        private Client client;
        private AccessConnection accessConnection;
        public Sender()
        {
            InitializeComponent();
            try
            {
                this.client = new Client();
                labelServerConnected.Text = "是";
            }
            catch (Exception e)
            {
                labelServerConnected.Text = "否";
            }
            accessConnection = new AccessConnection(System.Windows.Forms.Application.ExecutablePath);
            SetDataBaseConnectionLabel(accessConnection.OpenConnection());
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!(client is null))
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
                        client.SetDataPickInterval();
                    }                    
                    client.SetAcceesConnection(accessConnection);
                    GetProcessPattern();
                    client.Start();
                    SetTheButton(false);
                }
                else 
                {
                    client.End();
                }
            }
            else 
            {
                MessageBox.Show("无法连接至服务端,请检查");
            }
            SetTheButton(true);
        }

        private void SetTheButton(bool state) 
        {
            groupBox1.Enabled = state;
            buttonDataBaseChoose.Enabled = state;
            textBoxInterval.Enabled = state;
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                if (!(client is null)) 
                {
                    client.accessConnection.CloseConnection();
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

        private void SetDataBaseConnectionLabel(bool IsConntected) 
        {
            if (IsConntected)
            {
                labelDataBaseConnected.Text = "是";
            }
            else 
            {
                labelDataBaseConnected.Text = "否";
            }
        }

        private void buttonConnectToServer_Click(object sender, EventArgs e)
        {
            try
            {
                this.client = new Client();
            }
            catch (Exception exception) 
            {
                MessageBox.Show(exception.Message) ;
            }            
        }

        private void GetProcessPattern() 
        {
            if (radioButtonMaxValue.Checked)
            {
                client.processPattern = Lib.DataBase.Model.ProcessPattern.Max;
            }
            else if (radioButtonMinValue.Checked)
            {
                client.processPattern = Lib.DataBase.Model.ProcessPattern.Min;
            }
            else 
            {
                client.processPattern = Lib.DataBase.Model.ProcessPattern.Average;
            }
        }
    }
}
