using Lib.DataBase.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace Lib.DataBase
{
    public sealed class AccessConnection
    {
        private static AccessConnection instance = null;
        private static readonly object padlock = new object();
        private string _dataBasePath;
        private static string _providerName = "Microsoft.Jet.OLEDB.4.0";
        private string connectionName = "AccessMDBPath";
        private Configuration configuration;
        private OleDbConnection dataBaseConnection;
        private ConnectionStringSettings mySettings;
        private bool running = false;

        public bool IsConnected = false;
        public DataWrapper data;
        public DataProcess process;

        public static AccessConnection GetInstance(string file = "") 
        {
            if (instance == null)
            {
                lock (padlock) 
                {
                    if (instance == null) 
                    {
                        instance = new AccessConnection(file);
                    }
                }
            }
            return instance;

        }

        private AccessConnection(string file)
        {
            if (file == "")
            {

            }
            else
            {
                try
                {
                    configuration = ConfigurationManager.OpenExeConfiguration(file);
                    DateTime onOffRecordTime = Convert.ToDateTime(configuration.AppSettings.Settings["OnOffRecordTime"].Value);
                    DateTime tmpAndMoistTime = Convert.ToDateTime(configuration.AppSettings.Settings["TmpAndMoistTime"].Value);
                    data = new DataWrapper(onOffRecordTime, tmpAndMoistTime);
                    if (configuration.ConnectionStrings.ConnectionStrings[connectionName] != null)
                    {
                        _dataBasePath = SetDataBasePath
                            (configuration.ConnectionStrings.ConnectionStrings[connectionName].ProviderName,
                            configuration.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString);
                    }

                }
                catch (Exception e)
                {
                    throw new Exception("配置文件加载失败");
                }

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

        public string OpenConnection()
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
            return configuration.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString;
        }

        public void CloseConnection()
        {
            dataBaseConnection.Close();
        }

        public bool RefreshData(ProcessPattern pattern) 
        {
            process = new DataProcess(pattern);
            if (running == false)
            {
                running = !running;
            }
            //if (queryAlarmInfo() && queryOnOffRecord() && queryTmpAndMoist())
            if (queryOnOffRecord() && queryTmpAndMoist())
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
                configuration.AppSettings.Settings["OnOffRecordTime"].Value = data.OnOffRecordTime.ToString("yyyy-MM-dd HH:mm:ss");
                configuration.AppSettings.Settings["TmpAndMoistTime"].Value = data.TmpAndMoistDataTime.ToString("yyyy-MM-dd HH:mm:ss");
                configuration.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
            
            
        }

        //private bool queryAlarmInfo()
        //{
        //    try
        //    {
        //        //TODO: 表名通过配置文件配置
        //        string queryString = "SELECT * FROM MCGS_AlarmInfo";
        //        string timeCondition = getTimeCondition("TimeS");
        //        queryString += timeCondition;
        //        OleDbDataAdapter inst = new OleDbDataAdapter(queryString, dataBaseConnection);
        //        DataSet ds = new DataSet();
        //        inst.Fill(ds);                
        //        data.SetAlarmInfo(process.Process(ds.Tables[0]));
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return true;
        //}

        private bool queryOnOffRecord()
        {
            try
            {
                //TODO: 表名通过配置文件配置
                string queryString = "SELECT * FROM 开关量存盘_MCGS";
                string timeCondition = getOnOffRecordTimeCondition("MCGS_Time");
                queryString += timeCondition;
                OleDbDataAdapter inst = new OleDbDataAdapter(queryString, dataBaseConnection);
                DataSet ds = new DataSet();
                inst.Fill(ds);
                data.SetOnOffRecord(process.Process((ds.Tables[0])));
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
                string timeCondition = getTmpAndMoistDataTimeCondition("MCGS_Time");
                queryString += timeCondition;
                OleDbDataAdapter inst = new OleDbDataAdapter(queryString, dataBaseConnection);
                DataSet ds = new DataSet();
                inst.Fill(ds);
                data.SetTmpAndMoistData(process.Process(ds.Tables[0]));
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        private string getOnOffRecordTimeCondition(string keyWord) 
        {
            DateTime onOffRecordTime = Convert.ToDateTime(configuration.AppSettings.Settings["OnOffRecordTime"].Value);
            string result = " where " + keyWord + " > " + "#" + onOffRecordTime.ToString("yyyy-MM-dd HH:mm:ss") + "#";  
            return result;
        }

        private string getTmpAndMoistDataTimeCondition(string keyWord)
        {
            DateTime tmpAndMoistTime = Convert.ToDateTime(configuration.AppSettings.Settings["TmpAndMoistTime"].Value);
            string result = " where " + keyWord + " > " + "#" + tmpAndMoistTime.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            return result;
        }


    }
}
