using System;
using System.Data;
using System.Data.OleDb;

namespace Lib.DataBase
{
    public class AccessConnection
    {
        private string _dataBasePath;
        private OleDbConnection dataBaseConnection;
        public DataTable _AlarmInfo;
        public DataTable _tiong;
        public DataTable _tmpAndMoistData;


        public AccessConnection() { }

        ~AccessConnection() 
        {
            dataBaseConnection.Close();
        }

        public bool SetConnection(string dataBasePath) 
        {
            //TODO: 检查路径是否正确
            //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\project\cui\2019-12-15D(1).MDB
            this._dataBasePath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dataBasePath;
            return true;
        }

        public bool OpenConnection() 
        {
            try
            {
                dataBaseConnection = new OleDbConnection(_dataBasePath);
                dataBaseConnection.Open();
            }
            catch (Exception e) 
            {
                throw e;
            }
            if (queryAlarmInfo() && queryTiong() && queryTmpAndMoist()) 
            {
                return true;
            }
            return false;
        }

        public void CloseConnection() 
        {
            dataBaseConnection.Close();
        }

        private bool queryAlarmInfo() 
        {
            try
            {
                //TODO: 表名通过配置文件配置
                OleDbDataAdapter inst = new OleDbDataAdapter("SELECT * FROM MCGS_AlarmInfo", dataBaseConnection);
                DataSet ds = new DataSet();
                inst.Fill(ds);
                this._AlarmInfo = ds.Tables[0];
            }
            catch (Exception e) 
            {
                throw e;
            }
            return true;
        }

        private bool queryTiong()
        {
            try
            {
                //TODO: 表名通过配置文件配置
                OleDbDataAdapter inst = new OleDbDataAdapter("SELECT * FROM tiong_MCGS", dataBaseConnection);
                DataSet ds = new DataSet();
                inst.Fill(ds);
                _tiong = ds.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        private bool queryTmpAndMoist()
        {
            try
            {
                //TODO: 表名通过配置文件配置
                OleDbDataAdapter inst = new OleDbDataAdapter("SELECT * FROM 温湿度数据_MCGS", dataBaseConnection);
                DataSet ds = new DataSet();
                inst.Fill(ds);
                _tmpAndMoistData = ds.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
    }
}
