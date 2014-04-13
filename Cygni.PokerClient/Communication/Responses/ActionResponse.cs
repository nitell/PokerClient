using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.PokerClient.Communication.Responses
{
    public class ActionResponse : TexasResponse
    {
        public Cygni.PokerClient.Game.Action Action { get; set; }

        public ActionResponse(Cygni.PokerClient.Game.Action action, string requestId)
        {
            Type = "se.cygni.texasholdem.communication.message.response.ActionResponse";
            RequestId = requestId;
            Action = action;
        }
    }
}
