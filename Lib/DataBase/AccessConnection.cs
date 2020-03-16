﻿using Lib.DataBase.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace Lib.DataBase
{
    public class AccessConnection
    {
        private string _dataBasePath;
        private static string _providerName = "Microsoft.Jet.OLEDB.4.0";
        private string connectionName = "AccessMDBPath";
        private Configuration configuration;
        private OleDbConnection dataBaseConnection;
        private ConnectionStringSettings mySettings;
        private DateTime timeStamp;
        private bool running = false;

        public bool IsConnected = false;
        public DataWrapper data;



        public AccessConnection(string file)
        {
            data = new DataWrapper();
            try
            {
                configuration = ConfigurationManager.OpenExeConfiguration(file);
                if (configuration.ConnectionStrings.ConnectionStrings[connectionName] != null)
                {
                    _dataBasePath = SetDataBasePath
                        (configuration.ConnectionStrings.ConnectionStrings[connectionName].ProviderName,
                        configuration.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString);
                }

            }
            catch(Exception e)
            {
                throw new Exception("配置文件加载失败");
            }

        }

        //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\project\cui\2019-12-15D(1).MDB
        public bool SetConnection(string dataBasePath)
        {

            if (configuration.ConnectionStrings.ConnectionStrings[connectionName] != null)
            {
                configuration.ConnectionStrings.ConnectionStrings.Remove(connectionName);
            }
            mySettings = new ConnectionStringSettings(connectionName, dataBasePath, _providerName);
            configuration.ConnectionStrings.ConnectionStrings.Add(mySettings);
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            _dataBasePath = SetDataBasePath(mySettings.ProviderName, mySettings.ConnectionString);
            //TODO: 检查路径是否正确            
            return true;
        }

        private string SetDataBasePath(string provider, string connectionString)
        {
            return "Provider=" + provider + ";Data Source=" + connectionString;
        }

        public bool OpenConnection()
        {
            try
            {
                dataBaseConnection = new OleDbConnection(_dataBasePath);
                dataBaseConnection.Open();
                IsConnected = true;
            }
            catch
            {
            }
            //if (IsConnected)
            //{
            //    RefreshData();
            //}
            return IsConnected;
        }

        public void CloseConnection()
        {
            dataBaseConnection.Close();
        }

        public bool RefreshData() 
        {
            if (running == false)
            {
                string time = configuration.AppSettings.Settings["AccessTime"].Value;
                timeStamp = Convert.ToDateTime(time);
                running = !running;
            }
            if (queryAlarmInfo() && queryTiong() && queryTmpAndMoist())
            {
                data.CalculateSize();
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void ChangeTimeStamp() 
        {
            try
            {
                timeStamp = DateTime.Now;
                configuration.AppSettings.Settings["AccessTime"].Value = timeStamp.ToString("yyyy-MM-dd hh:mm:ss");
                configuration.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
            
            
        }

        private bool queryAlarmInfo()
        {
            try
            {
                //TODO: 表名通过配置文件配置
                string queryString = "SELECT * FROM MCGS_AlarmInfo";
                string timeCondition = getTimeCondition("TimeS");
                queryString += timeCondition;
                OleDbDataAdapter inst = new OleDbDataAdapter(queryString, dataBaseConnection);
                DataSet ds = new DataSet();
                inst.Fill(ds);
                data.SetAlarmInfo(ds.Tables[0]);
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
                string queryString = "SELECT * FROM tiong_MCGS";
                string timeCondition = getTimeCondition("MCGS_Time");
                queryString += timeCondition;
                OleDbDataAdapter inst = new OleDbDataAdapter(queryString, dataBaseConnection);
                DataSet ds = new DataSet();
                inst.Fill(ds);
                data.SetTiong(ds.Tables[0]);
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
                string queryString = "SELECT * FROM 温湿度数据_MCGS";
                string timeCondition = getTimeCondition("MCGS_Time");
                queryString += timeCondition;
                OleDbDataAdapter inst = new OleDbDataAdapter(queryString, dataBaseConnection);
                DataSet ds = new DataSet();
                inst.Fill(ds);
                data.SetTmpAndMoistData(ds.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        private string getTimeCondition(string keyWord) 
        {
            if (timeStamp == null) 
            {
                return null;
            }
            string result = " where " + keyWord + " > " + "#" + timeStamp.ToString("yyyy-MM-dd hh:mm:ss") + "#";  
            return result;
        }


    }
}
