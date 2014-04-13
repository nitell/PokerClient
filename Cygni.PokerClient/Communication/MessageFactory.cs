using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cygni.PokerClient.Communication
{
    public class MessageFactory
    {
  

        public MessageFactory()
        {

        }

        public TexasMessage CreateMessage(string msg)
        {
            var deserializer = new JsonSerializer();
            deserializer.Converters.Add(new ResponseCreationConverter());
            deserializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return deserializer.Deserialize<TexasMessage>(new JsonTextReader(new StringReader(msg)))
                   ?? new UnknownMessage { StringData = msg };
        }
    }
}
