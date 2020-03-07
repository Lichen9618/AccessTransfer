using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lib.DataTransfer;

namespace AccessTransferClient
{
    public partial class Sender : Form
    {
        private Client client;
        public Sender()
        {
            this.client = new Client("127.0.0.1", 8888);
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.SetSend();
            if (client.StartToSend == true) 
            {
                client.Start();
            }                       
        }

        private void Close(object sender, FormClosingEventArgs e) 
        {
            DialogResult dr = MessageBox.Show("是否退出?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                client.End();
                e.Cancel = false;
            }
            else if(dr == DialogResult.Cancel) 
            {
                e.Cancel = true;
            }

        }
    }
}
