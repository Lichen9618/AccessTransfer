using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using Lib.DataTransfer;

namespace Lib.DataBase.Model
{
    public class DataWrapper
    {
        public DataTable _AlarmInfo;
        public DataTable _tiong;
        public DataTable _tmpAndMoistData;

        public bool SetAlarmInfo(DataTable alarmInfo) 
        {
            //TODO:数据是否正确检查
            _AlarmInfo = alarmInfo;
            return true;
        }

        public bool SetTiong(DataTable tiong) 
        {
            //TODO:数据是否正确检查
            _tiong = tiong;
            return true;
        }

        public bool SetTmpAndMoistData(DataTable tmpAndMoistData) 
        {
            //TODO:数据是否正确检查
            _tmpAndMoistData = tmpAndMoistData;
            return true;
        }

        public bool IsReady() 
        {
            if (_AlarmInfo is null || _tiong is null || _tmpAndMoistData is null)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public byte[] SendData() 
        {
            if (IsReady())
            {
                return Encoding.UTF8.GetBytes(Serialize());
            }
            else 
            {
                return null;
            }
        }

        public string Serialize() 
        {
            return JsonHelper.SerializeObject(this);
        }

        public DataWrapper Deserialize(string data) 
        {
            try
            {
                var result = JsonHelper.DeserializeToObject<DataWrapper>(data);
                return result;
            }
            catch (Exception e) 
            {
                throw e;
            }            
        }
    }
}
