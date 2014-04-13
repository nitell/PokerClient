using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cygni.PokerClient.Communication
{
    class ResponseCreationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {

            var jsonObject = JObject.Load(reader);
            var type = (jsonObject["type"] ?? "").ToString();
            var className = type.Split('.').Last();


            var netType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == className);
            if (netType == null)
                return null;

            return jsonObject.ToObject(netType);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}