using Poker.Entity;
using Poker1.Models;
using Poker1.Services;

namespace PokerTry2.Controllers
{

    public class ResultController
    {
        private readonly IResultService resultService;
        private readonly IPlayerService playerService;

        public ResultController(IResultService resultService, IPlayerService playerService)
        {
            this.resultService = resultService;
            this.playerService = playerService;
        }

        public async Task DeterminateResult()
        {
            resultService.DeterminateResult();
        }
    }
}
