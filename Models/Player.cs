using Poker1.Models;
using PokerTry2.Models;
using System.Collections.Generic;

namespace Poker.Entity
{
    /// <summary>
    /// Player Class represents a Poker Player with Name and Hand objects
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public int Stack { get; set; } = 2000;
        public bool IsDealer { get; set; }
        public int CurrentBet { get; set; }
        public bool IsFolded { get; set; }
        public bool IsAllIn { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
        public PlayerPosition Position { get; private set; }

        public Player(string name, PlayerPosition position, bool isDealer = false)
        {
            Name = name;
            IsDealer = isDealer;
            Position = position;
        }

        // public static bool playerHandEquals(Player player1, Player player2)
        // {
        //     int cardIndex = 0;
        //     bool result = true; // assume first cards are equal
        //
        //     while (cardIndex < player1.Cards.Count && result == true)
        //     {
        //         if (player1.Cards[cardIndex].Rank == player2.Cards[cardIndex].Rank)
        //             result = true;
        //         else if (player1.Cards[cardIndex].Rank < player2.Cards[cardIndex].Rank)
        //             result = false;
        //         else if (player1.Cards[cardIndex].Rank > player2.Cards[cardIndex].Rank)
        //             result = false;
        //
        //         cardIndex++;
        //     }
        //
        //     return result;
        // }

        /// <summary>
        /// A IComparer implementation for Player to sort the hand by HandType and HandScore
        /// </summary>
        // public class PlayerPokerHandScoreComparer : IComparer<Player>
        // {
        //     public int Compare(Player player1, Player player2)
        //     {
        //         // Сравнение типов руки
        //         //int result = player2.HandRank.
        //         //    CompareTo(player1.HandRank);
        //         // Сравнение счета руки если одинаковая рука
        //         //if (result == 0)
        //         //    result = player2.Hand.PokerHandScore.Score.
        //         //    CompareTo(player1.Hand.PokerHandScore.Score);
        //
        //         return 1;
        //     }
        // }

        /// <summary>
        /// /// Реализация IComparer для Player для сравнения карт двух игроков и основе HighCard
        /// </summary>
        public class PlayerHighCardComparer : IComparer<Player>
        {
            public int Compare(Player player1, Player player2)
            {
                int cardIndex = 0;
                int result = 0; // assume first cards are equal

                while (cardIndex < player1.Cards.Count && result == 0)
                {
                    if (player1.Cards[cardIndex].Rank == player2.Cards[cardIndex].Rank)
                        result = 0;
                    else if (player1.Cards[cardIndex].Rank < player2.Cards[cardIndex].Rank)
                        result = 1;
                    else if (player1.Cards[cardIndex].Rank > player2.Cards[cardIndex].Rank)
                        result = -1;

                    cardIndex++;
                }

                return result;
            }
        }
    }
}
