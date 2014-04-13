using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.PokerClient.Game
{
    public class Hand
    {
        public List<Card> Cards { get; set; }
        public PokerHand PokerHand { get; set; }
        public bool Folded { get; set; }
    }
}
