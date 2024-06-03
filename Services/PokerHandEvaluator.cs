using Poker.Models;
using Poker1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTry2.Services
{
    public enum HandRankType
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    public class HandRank : IComparable<HandRank>
    {
        public HandRankType RankType { get; set; }
        public List<CardRank> HighCards { get; set; }

        public int CompareTo(HandRank other)
        {
            if (RankType != other.RankType)
            {
                return RankType.CompareTo(other.RankType);
            }
            for (int i = 0; i < HighCards.Count; i++)
            {
                if (HighCards[i] != other.HighCards[i])
                {
                    return HighCards[i].CompareTo(other.HighCards[i]);
                }
            }
            return 0;
        }
        public override string ToString()
        {
            return RankType.ToString();
        }
    }

    public class PokerHandEvaluator
    {
        public HandRank EvaluateHand(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("A hand must consist of exactly 5 cards.");
            }

            var groupedByRank = cards.GroupBy(c => c.Rank).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).ToList();
            var groupedBySuit = cards.GroupBy(c => c.Suit).OrderByDescending(g => g.Count()).ToList();

            // Check for Flush
            if (groupedBySuit.First().Count() == 5)
            {
                var flushCards = groupedBySuit.First().OrderByDescending(c => c.Rank).ToList();
                // Check for Straight Flush (and Royal Flush)
                var straightFlush = CheckStraight(flushCards);
                if (straightFlush != null)
                {
                    if (straightFlush.HighCards.First() == CardRank.Ace) // Ace-high
                    {
                        return new HandRank { RankType = HandRankType.RoyalFlush, HighCards = straightFlush.HighCards };
                    }
                    return new HandRank { RankType = HandRankType.StraightFlush, HighCards = straightFlush.HighCards };
                }
                return new HandRank { RankType = HandRankType.Flush, HighCards = flushCards.Select(c => c.Rank).ToList() };
            }

            // Check for Straight
            var straight = CheckStraight(cards);
            if (straight != null)
            {
                return new HandRank { RankType = HandRankType.Straight, HighCards = straight.HighCards };
            }

            // Check for Four of a Kind
            if (groupedByRank.First().Count() == 4)
            {
                return new HandRank
                {
                    RankType = HandRankType.FourOfAKind,
                    HighCards = new List<CardRank> { groupedByRank.First().Key, groupedByRank.Skip(1).First().Key }
                };
            }

            // Check for Full House
            if (groupedByRank.First().Count() == 3 && groupedByRank.Skip(1).First().Count() == 2)
            {
                return new HandRank
                {
                    RankType = HandRankType.FullHouse,
                    HighCards = new List<CardRank> { groupedByRank.First().Key, groupedByRank.Skip(1).First().Key }
                };
            }

            // Check for Three of a Kind
            if (groupedByRank.First().Count() == 3)
            {
                return new HandRank
                {
                    RankType = HandRankType.ThreeOfAKind,
                    HighCards = new List<CardRank> { groupedByRank.First().Key, groupedByRank.Skip(1).First().Key, groupedByRank.Skip(2).First().Key }
                };
            }

            // Check for Two Pair
            if (groupedByRank.First().Count() == 2 && groupedByRank.Skip(1).First().Count() == 2)
            {
                return new HandRank
                {
                    RankType = HandRankType.TwoPair,
                    HighCards = new List<CardRank> { groupedByRank.First().Key, groupedByRank.Skip(1).First().Key, groupedByRank.Skip(2).First().Key }
                };
            }

            // Check for One Pair
            if (groupedByRank.First().Count() == 2)
            {
                return new HandRank
                {
                    RankType = HandRankType.OnePair,
                    HighCards = new List<CardRank> { groupedByRank.First().Key, groupedByRank.Skip(1).First().Key, groupedByRank.Skip(2).First().Key, groupedByRank.Skip(3).First().Key }
                };
            }

            // High Card
            return new HandRank
            {
                RankType = HandRankType.HighCard,
                HighCards = groupedByRank.SelectMany(g => g.Select(c => c.Rank)).Take(5).ToList()
            };
        }

        private HandRank CheckStraight(List<Card> cards)
        {
            var orderedCards = cards.OrderByDescending(c => c.Rank).Select(c => c.Rank).Distinct().ToList();
            for (int i = 0; i <= orderedCards.Count - 5; i++)
            {
                if ((int)orderedCards[i] - (int)orderedCards[i + 4] == 4)
                {
                    return new HandRank { HighCards = orderedCards.Skip(i).Take(5).ToList() };
                }
            }
            // Check for Ace-low straight (A, 2, 3, 4, 5)
            if (orderedCards.Contains(CardRank.Ace) && orderedCards.Take(4).SequenceEqual(new List<CardRank> { CardRank.Five, CardRank.Four, CardRank.Three, CardRank.Two }))
            {
                return new HandRank { HighCards = new List<CardRank> { CardRank.Five, CardRank.Four, CardRank.Three, CardRank.Two, CardRank.Ace } };
            }
            return null;
        }
    }
}
