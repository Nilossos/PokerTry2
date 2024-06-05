using System;
using Poker.Models;
using PokerTry2.Properties;

namespace Poker1.Models
{
    public class Bet
    {
        public BetType Type { get; set; }
        public int Amount { get; set; }
        public Bet(BetType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
