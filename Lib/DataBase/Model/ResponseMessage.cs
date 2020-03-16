using Lib.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.DataBase.Model
{
    public class ResponseMessage
    {
        public int Length = 0;
        public DateTime Time;

        public ResponseMessage(int length) 
        {
            Time = DateTime.Now;
            Length = length;
        }

        public byte[] SendData() 
        {
            return Encoding.UTF8.GetBytes(Serialize());
        }

        public string Serialize() 
        {
            return JsonHelper.SerializeObject(this);
        }

        public static ResponseMessage Deserialize(string data) 
        {
            try
            {
                var result = JsonHelper.DeserializeToObject<ResponseMessage>(data);
                return result;
            }
            catch (Exception e) 
            {
                throw e;
            }
        }
    }
}
