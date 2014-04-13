using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.PokerClient.Game
{
    public class PlayerShowDown
    {        
        public GamePlayer Player { get; set; }
         public Hand Hand { get; set; }
         public long WonAmount { get; set; }

    }
}
