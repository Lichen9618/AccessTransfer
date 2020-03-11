using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lib.DataTransfer
{
    public class JsonHelper
    {
        public static string SerializeObject(object data) 
        {
            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        public static T DeserializeToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader reader = new StringReader(json);
            object data = serializer.Deserialize(new JsonTextReader(reader), typeof(T));
            T result = data as T;
            return result;
        }
    }
}
