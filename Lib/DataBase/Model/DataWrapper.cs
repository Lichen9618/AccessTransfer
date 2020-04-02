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
        //public DataTable _AlarmInfo;
        public DataTable _onOffRecord;
        public DataTable _tmpAndMoistData;
        public int recordCount = 0;

        public string clientName;

        public DateTime OnOffRecordTime;
        public DateTime TmpAndMoistDataTime;

        public DataWrapper(DateTime onOffRecordTime, DateTime tmpAndMoistDataTime) 
        {
            OnOffRecordTime = onOffRecordTime;
            TmpAndMoistDataTime = tmpAndMoistDataTime;
        }

        public void SetInformation(string Name) 
        {
            clientName = Name;
        }

        public void CalculateSize() 
        {
            recordCount = _onOffRecord.Rows.Count + _tmpAndMoistData.Rows.Count;
        }

        //public bool SetAlarmInfo(DataTable alarmInfo) 
        //{
        //    //TODO:数据是否正确检查
        //    _AlarmInfo = alarmInfo;
        //    return true;
        //}

        public bool SetOnOffRecord(DataTable onOffRecord)
        {
            //TODO:数据是否正确检查
            _onOffRecord = onOffRecord;
            OnOffRecordTime = (DateTime)onOffRecord.Rows[0][0];
            return true;
        }

        public bool SetTmpAndMoistData(DataTable tmpAndMoistData) 
        {
            //TODO:数据是否正确检查
            _tmpAndMoistData = tmpAndMoistData;
            TmpAndMoistDataTime = (DateTime)tmpAndMoistData.Rows[0][0];
            return true;
        }

        public bool IsReady() 
        {
            if (recordCount == 0)
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

        public static DataWrapper Deserialize(string data) 
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
