using System;
using System.Collections.Generic;
using Poker.Models;

namespace Poker1.Models
{
    public class Deck
    {
        private List<Card> Cards;
        private int cardsUsed = 0;
        public Deck()
        {
            Cards = new List<Card>(52);

            for (int suit = 0; suit <= 3; suit++)
            {
                for (int rank = 0; rank <= 12; rank++)
                {
                    Cards.Add(new Card((CardSuits)System.Enum.GetValues(typeof(CardSuits)).GetValue(suit),
                        (CardRank)System.Enum.GetValues(typeof(CardRank)).GetValue(rank)));
                }
            }
            this.shuffle();
        }
        public void shuffle()
        {
            Random random = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int n = random.Next(i + 1);
                Card temp = Cards[i];
                Cards[i] = Cards[n];
                Cards[n] = temp;
            }
        }

        public Card getCard()
        {
            if (cardsUsed == Cards.Count)
                throw new Exception("No cards are left in the deck.");

            cardsUsed++;
            return Cards[cardsUsed - 1];
        }
    }
}
