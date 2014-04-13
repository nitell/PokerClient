using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.PokerClient.Game
{
    public class Card
    {
        public Card()
        {

        }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public override string ToString()
        {
            return String.Format("{0} of {1}", Rank, Suit);
        }
    }
}
