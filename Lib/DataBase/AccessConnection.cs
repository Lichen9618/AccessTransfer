﻿using System;
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

        public bool IsConnected = false;
        public DataTable _AlarmInfo;
        public DataTable _tiong;
        public DataTable _tmpAndMoistData;



        public AccessConnection(string file)
        {
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

        ~AccessConnection()
        {
            dataBaseConnection.Close();
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
            if (IsConnected)
            {
                if (queryAlarmInfo() && queryTiong() && queryTmpAndMoist())
                {
                    return true;
                }
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
