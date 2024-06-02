using System;
using Poker.Models;
using PokerTry2.Properties;

namespace Poker1.Models
{
    public class Card : IComparable<Card>
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public Image Image { get; set; }
        public Card(CardSuit suit, CardRank rank)
        {
            Rank = rank;
            Suit = suit;

            string resourceName = $"{suit}s_{rank}";
            Image = (Image)Resources.ResourceManager.GetObject(resourceName);

            if (Image == null)
            {
                throw new Exception($"Image not found for {resourceName}");
            }
        }

        
        /// <summary>
        /// CompareTo implementation for sorting by Rank.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Card other)
        {
            return other.Rank.CompareTo(Rank);
        }
    }
}
