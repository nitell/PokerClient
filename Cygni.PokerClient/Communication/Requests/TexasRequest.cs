using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.PokerClient.Communication.Requests
{
    public class TexasRequest : TexasMessage
    {
        public string RequestId { get; set; }
        public string SessionId { get; set; }

        public TexasRequest()
        {

        }

        public TexasRequest(string type)
        {
            RequestId = Guid.NewGuid().ToString();
            Type = type;
        } 

    }
}
