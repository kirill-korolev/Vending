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
        public static Wrapper<T> Read<T>(string fileName)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(@"../../content/json/", fileName)))
            {
                var json = reader.ReadToEnd();
                var wrapper = JsonConvert.DeserializeObject<Wrapper<T>>(json);
                return wrapper;
            }
        }
    }
}
