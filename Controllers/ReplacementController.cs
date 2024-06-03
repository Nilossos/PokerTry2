using Poker.Entity;
using Poker1.Models;
using Poker1.Services;

namespace PokerTry2.Controllers
{

    public class ReplacementController
    {
        private readonly IReplacementService replacementService;
        private readonly IPlayerService playerService;

        public ReplacementController(IReplacementService replacementService, IPlayerService playerService)
        {
            this.replacementService = replacementService;
            this.playerService = playerService;
        }

        public async Task StartReplacements()
        {
            await replacementService.RunReplacementRound();
        }

        public async Task Replace(Player player, List<Card> cards)
        {
            replacementService.PlayerMadeMove();
            await playerService.Replace(player, cards);
        }
    }
}
