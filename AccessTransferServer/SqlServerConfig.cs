using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using Lib.DataBase;

namespace AccessTransferServer
{
    public partial class SqlServerConfig : Form
    {
        SqlServerConnection connection;

        public SqlServerConfig(string path)
        {
            InitializeComponent();
            connection = SqlServerConnection.GetInstance(path);
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text == "" || textBoxDataBase.Text == "")
            {
                MessageBox.Show("Server与DataBase不能为空!");
            }
            else 
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection
                        (System.Text.RegularExpressions.Regex.Unescape
                        (connection.CreateConnectionString
                        (textBoxServer.Text, textBoxDataBase.Text, textBoxuid.Text, textBoxpwd.Text))))
                    {
                        sqlConnection.Open();
                        MessageBox.Show("连接成功!");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text != "" && textBoxDataBase.Text != "")
            {
                if (connection.SetDataBaseConnection(textBoxServer.Text, textBoxDataBase.Text, textBoxuid.Text, textBoxpwd.Text))
                {
                    MessageBox.Show("数据库配置成功");
                }
                else 
                {
                    MessageBox.Show("数据库配置失败");
                }
            }
            this.Close();
        }
    }
}
