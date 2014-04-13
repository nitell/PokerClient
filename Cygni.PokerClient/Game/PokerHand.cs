using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.PokerClient.Game
{
    public enum PokerHand
    {
        ROYAL_FLUSH = 10,
        STRAIGHT_FLUSH = 9,
        FOUR_OF_A_KIND = 8,
        FULL_HOUSE = 7,
        FLUSH = 6,
        STRAIGHT = 5,
        THREE_OF_A_KIND = 4,
        TWO_PAIRS = 3,
        ONE_PAIR = 2,
        HIGH_HAND = 1,
        NOTHING = 0
    }
}
