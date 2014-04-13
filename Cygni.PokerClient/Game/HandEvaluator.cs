using System;
using System.Collections.Generic;
using System.Linq;

namespace Cygni.PokerClient.Game
{
    public class HandEvaluator
    {
        public PokerHand Evaluate(params Card[] cards)
        {
            var straight = FindStraight(cards);
            if (straight != null)
            {
                //Is it a flush/royal?
                var straightFlush = cards.GroupBy(c => c.Suit).Select(FindStraight).FirstOrDefault(s => s != null);
                if (straightFlush != null)
                {
                    return straightFlush.First().Rank == Rank.ACE ? PokerHand.ROYAL_FLUSH : PokerHand.STRAIGHT_FLUSH;
                }
            }

            var groupByRank = cards.GroupBy(c => c.Rank).ToArray();
            if (groupByRank.Any(g => g.Count() >= 4))
                return PokerHand.FOUR_OF_A_KIND;

            var trips = groupByRank.FirstOrDefault(g => g.Count() >= 3);
            var pairs = groupByRank.Where(g => trips == null || g.Key != trips.Key).Where(g => g.Count() >= 2).ToArray();
            if (trips != null && pairs.Any())
                return PokerHand.FULL_HOUSE;

            if (cards.GroupBy(c => c.Suit).Any(g => g.Count() >= 5))
                return PokerHand.FLUSH;

            if (straight != null)
                return PokerHand.STRAIGHT;

            if (trips != null)
                return PokerHand.THREE_OF_A_KIND;

            if (pairs.Count() >= 2)
                return PokerHand.TWO_PAIRS;

            if (pairs.Any())
                return PokerHand.ONE_PAIR;

            return PokerHand.NOTHING;
        }

        private Card[] FindStraight(IEnumerable<Card> cards)
        {
            //Multiple cards may have the same rank.
            var ranks = cards.GroupBy(c => c.Rank).OrderByDescending(g => g.Key).Select(g => g.First()).ToArray();

            //Aces can also be treated as ones
            if (ranks.First().Rank == Rank.ACE)
            {
                Array.Resize(ref ranks, ranks.Length + 1);
                ranks[ranks.Length - 1] = ranks[0];
            }

            int foundInARow = 1;
            for (int i = 0; i < ranks.Length - 1; i++)
            {
                foundInARow = Follows(ranks[i + 1].Rank, ranks[i].Rank) ? foundInARow + 1 : 1;
                if (foundInARow == 5)
                    return ranks.Skip(i - 3).Take(5).ToArray();
            }
            return null;
        }

        private bool Follows(Rank lower, Rank higher)
        {
            //Special case, 2 follows ace
            if (lower == Rank.ACE && higher == Rank.DEUCE)
                return true;

            return (int)lower + 1 == (int)higher;
        }
    }
}
