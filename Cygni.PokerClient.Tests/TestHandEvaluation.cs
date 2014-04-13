using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Cygni.PokerClient.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Cygni.PokerClient.Tests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [TestClass]
    public class TestHandEvaluation
    {
        [TestMethod]
        public void FindNothing()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
                new Card(Rank.FIVE, Suit.CLUBS),
                new Card(Rank.QUEEN, Suit.HEARTS),
                new Card(Rank.EIGHT, Suit.SPADES),
                new Card(Rank.EIGHT, Suit.CLUBS),
                new Card(Rank.JACK, Suit.SPADES),
                new Card(Rank.DEUCE, Suit.SPADES));
            Assert.AreEqual(PokerHand.ONE_PAIR, hand);
        }

        [TestMethod]
        public void FindOnePair()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
                new Card(Rank.FIVE, Suit.CLUBS),
                new Card(Rank.FIVE, Suit.HEARTS),
                new Card(Rank.EIGHT, Suit.SPADES),
                new Card(Rank.KING, Suit.CLUBS),
                new Card(Rank.JACK, Suit.SPADES),
                new Card(Rank.DEUCE, Suit.SPADES));
            Assert.AreEqual(PokerHand.ONE_PAIR, hand);
        }

        [TestMethod]
        public void FindTwoPairs()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
                new Card(Rank.FIVE, Suit.CLUBS),
                new Card(Rank.FIVE, Suit.HEARTS),
                new Card(Rank.EIGHT, Suit.SPADES),
                new Card(Rank.EIGHT, Suit.CLUBS),
                new Card(Rank.JACK, Suit.SPADES),
                new Card(Rank.DEUCE, Suit.SPADES));
            Assert.AreEqual(PokerHand.TWO_PAIRS, hand);
        }

        [TestMethod]
        public void FindThreeofAKind()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
                new Card(Rank.FIVE, Suit.CLUBS),
                new Card(Rank.FIVE, Suit.HEARTS),
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.EIGHT, Suit.CLUBS),
                new Card(Rank.JACK, Suit.SPADES),
                new Card(Rank.DEUCE, Suit.SPADES));
            Assert.AreEqual(PokerHand.THREE_OF_A_KIND, hand);
        }

        [TestMethod]
        public void FindStraight()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
                new Card(Rank.FIVE, Suit.CLUBS),
                new Card(Rank.FOUR, Suit.HEARTS),
                new Card(Rank.THREE, Suit.DIAMONDS),
                new Card(Rank.SIX, Suit.CLUBS),
                new Card(Rank.SEVEN, Suit.SPADES),
                new Card(Rank.DEUCE, Suit.SPADES));
            Assert.AreEqual(PokerHand.STRAIGHT, hand);
        }

        [TestMethod]
        public void FindFlush()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
                new Card(Rank.FIVE, Suit.SPADES),
                new Card(Rank.EIGHT, Suit.SPADES),
                new Card(Rank.THREE, Suit.SPADES),
                new Card(Rank.KING, Suit.CLUBS),
                new Card(Rank.SEVEN, Suit.SPADES),
                new Card(Rank.DEUCE, Suit.SPADES));
            Assert.AreEqual(PokerHand.FLUSH, hand);
        }

        [TestMethod]
        public void FindFullHouse()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
                new Card(Rank.FIVE, Suit.SPADES),
                new Card(Rank.FIVE, Suit.HEARTS),
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.EIGHT, Suit.CLUBS),
                new Card(Rank.EIGHT, Suit.DIAMONDS),
                new Card(Rank.DEUCE, Suit.HEARTS));
            Assert.AreEqual(PokerHand.FULL_HOUSE, hand);
        }

        [TestMethod]
        public void FindFourOfAKind()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
                new Card(Rank.FIVE, Suit.SPADES),
                new Card(Rank.FIVE, Suit.HEARTS),
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.EIGHT, Suit.CLUBS),
                new Card(Rank.EIGHT, Suit.DIAMONDS),
                new Card(Rank.FIVE, Suit.DIAMONDS));
            Assert.AreEqual(PokerHand.FOUR_OF_A_KIND, hand);
        }

        [TestMethod]
        public void FindStraightFlush()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
               new Card(Rank.DEUCE, Suit.SPADES),
               new Card(Rank.ACE, Suit.SPADES),
               new Card(Rank.THREE, Suit.SPADES),
               new Card(Rank.KING, Suit.CLUBS),
               new Card(Rank.FIVE, Suit.SPADES),
               new Card(Rank.FOUR, Suit.SPADES));
            Assert.AreEqual(PokerHand.STRAIGHT_FLUSH, hand);
        }

        [TestMethod]
        public void FindRoyalStraightFlush()
        {
            var evaluator = new HandEvaluator();
            var hand = evaluator.Evaluate(
               new Card(Rank.KING, Suit.SPADES),
               new Card(Rank.ACE, Suit.SPADES),
               new Card(Rank.QUEEN, Suit.SPADES),
               new Card(Rank.KING, Suit.CLUBS),
               new Card(Rank.JACK, Suit.SPADES),
               new Card(Rank.TEN, Suit.SPADES));
            Assert.AreEqual(PokerHand.ROYAL_FLUSH, hand);
        }
    }
}
