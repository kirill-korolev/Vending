using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Vending
{
    public abstract class JsonItemConverter<T>: Newtonsoft.Json.Converters.CustomCreationConverter<T>
    {
        public override T Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public abstract T Create(Type objectType, JObject jObject);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            JObject jObject = JObject.Load(reader);

            var target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }

    public class JsonMoneyConverter: JsonItemConverter<Money>
    {
        public override Money Create(Type objectType, JObject jObject)
        {
            bool isCoin = (bool)jObject.Property("IsCoin");

            switch (isCoin)
            {
                case true:
                    return new Coin();
                case false:
                    return new Bill();
                default:
                    return new Money();
            }
        }
    }
}
