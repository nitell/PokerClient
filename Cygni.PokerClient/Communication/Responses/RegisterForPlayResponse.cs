using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.PokerClient.Communication.Responses
{
    public class RegisterForPlayResponse : TexasResponse
    {
        public String SessionId { get; set; }
    }
}
