using Poker.Entity;
using Poker1.Models;
using Poker1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTry2.Controllers
{

    public class BetController
    {
        private readonly IBettingRoundService bettingRoundService;
        private readonly IPlayerService playerService;

        public BetController(IBettingRoundService bettingRoundService, IPlayerService playerService)
        {
            this.bettingRoundService = bettingRoundService;
            this.playerService = playerService;
        }

        public async Task StartBets()
        {
            await bettingRoundService.RunBettingRound();
        }

        public void Bet(Player player, int amount)
        {
            playerService.Bet(player, amount);
            bettingRoundService.PlayerMadeMove();
        }

        public void Call(Player player)
        {
            playerService.Call(player);
            bettingRoundService.PlayerMadeMove();
        }

        public void Fold(Player player)
        {
            playerService.Fold(player);
            bettingRoundService.PlayerMadeMove();
        }
    }
}
