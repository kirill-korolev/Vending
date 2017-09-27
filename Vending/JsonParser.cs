using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Vending
{
    public static class JsonParser
    {
        public static Wrapper<T> Read<T>(string fileName, JsonItemConverter<T> converter)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(Config.JsonPath, fileName)))
            {
                var json = reader.ReadToEnd();
                if(converter == null) return JsonConvert.DeserializeObject<Wrapper<T>>(json);
                else return JsonConvert.DeserializeObject<Wrapper<T>>(json, converter);
            }
        }
    }
}
