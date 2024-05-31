using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Models
{
    /// <summary>
    /// Represents the Type for a Bet
    /// </summary>
    public class Bet
    {
        public BetType Type { get; set; }
        public int Amount { get; set; }
    }
}
