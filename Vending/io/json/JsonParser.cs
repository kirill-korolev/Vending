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
        public static Wrapper<T> ReadCollection<T>(string fileName, JsonItemConverter<T> converter=null)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(Config.JsonPath, fileName)))
            {
                var json = reader.ReadToEnd();

                if (converter == null) return JsonConvert.DeserializeObject<Wrapper<T>>(json);
                else return JsonConvert.DeserializeObject<Wrapper<T>>(json, converter);
            }
        }

        public static T Read<T>(string fileName)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(Config.JsonPath, fileName)))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static void Write<T>(string fileName, T obj)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(Config.JsonPath, fileName)))
            {               
                string output = JsonConvert.SerializeObject(obj, Formatting.Indented);
                writer.Write(output);
            }
        }
    }
}
