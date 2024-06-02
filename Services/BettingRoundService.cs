using Poker.Entity;
using Poker1.Models;
using PokerTry2.Services;

namespace Poker1.Services;

public interface IBettingRoundService
{
    public Task RunBettingRound();
}

public class BettingRoundService : IBettingRoundService
{
    private readonly IGameStateService gameStateService;
    private readonly IDrawer drawer;
    private readonly IPlayerService playerService;
    private int currentPlayerIndex = 0;

    public BettingRoundService(IGameStateService gameStateService, IDrawer drawer, IPlayerService playerService)
    {
        this.gameStateService = gameStateService;
        this.drawer = drawer;
        this.playerService = playerService;
    }

    public async Task RunBettingRound()
    {
        drawer.DeactivateButtons(gameStateService.ButtonsField);
        bool exitLoop = false;
        bool bettingComplete = false;
        int dealerIndex = gameStateService.Players.FindIndex(p => p.IsDealer);

        while (!bettingComplete && !exitLoop)
        {
            for (int i = currentPlayerIndex; i <= gameStateService.Players.Count; i++)
            {
                currentPlayerIndex = (dealerIndex + i) % gameStateService.Players.Count;
                Player currentPlayer = gameStateService.Players[currentPlayerIndex];
                if (!currentPlayer.IsFolded && !currentPlayer.IsAllIn)
                {
                    if (currentPlayer != gameStateService.Players.First())
                    {
                        await Task.Delay(1000);
                        MakeBotMove(currentPlayer);
                        await Task.Delay(1000);
                    }
                    else
                    {
                        drawer.ActivateButtons(gameStateService.ButtonsField);
                        exitLoop = true;
                        break;
                    }
                }
                bettingComplete = CheckBettingComplete();
            }
        }
    }

    private async Task MakeBotMove(Player bot)
    {
        if (bot.Stack <= gameStateService.CurrentGlobalBet)
        {
            playerService.Call(bot);
        }
        else
        {
            var random = new Random();
            var action = random.Next(0, 3); // 0 - call, 1 - raise, 2 - fold

            switch (action)
            {
                case 0:
                    playerService.Call(bot);
                    break;
                case 1:
                    var raiseAmount = random.Next(1, bot.Stack / 6);
                    playerService.Bet(bot, raiseAmount);
                    break;
                case 2:
                    playerService.Fold(bot);
                    break;
            }
        }
    }

    private bool CheckBettingComplete()
    {
        int highestBet = gameStateService.Players.Max(p => p.CurrentBet);
        return gameStateService.Players.All(p => p.IsFolded || p.IsAllIn || p.CurrentBet == highestBet);
    }
}