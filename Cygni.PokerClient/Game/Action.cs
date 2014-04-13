using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cygni.PokerClient.Game
{
    public class Action
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionType ActionType { get; set; }
        public long Amount { get; set; }      

    }
}
