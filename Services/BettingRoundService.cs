using Poker.Entity;
using Poker1.Models;
using PokerTry2.Services;

namespace Poker1.Services;

public interface IBettingRoundService
{
    public Task RunBettingRound();
    public void PlayerMadeMove();
}

public class BettingRoundService : IBettingRoundService
{
    private readonly IGameStateService gameStateService;
    private readonly IDrawer drawer;
    private readonly IPlayerService playerService;
    private TaskCompletionSource<bool> playerMoveTcs;
    private bool dealerMoved = false;

    public BettingRoundService(IGameStateService gameStateService, IDrawer drawer, IPlayerService playerService)
    {
        this.gameStateService = gameStateService;
        this.drawer = drawer;
        this.playerService = playerService;
    }
    //FIXME Сделать победу последнего игрока с картами
    public async Task RunBettingRound()
    {
        drawer.DrawStacks(gameStateService.Players, gameStateService.TableField);
        drawer.DeactivateButtons(gameStateService.ButtonsField);
        bool bettingComplete = false;
        int dealerIndex = gameStateService.Players.FindIndex(p => p.IsDealer);
        int currentPlayerIndex = (dealerIndex + 1) % gameStateService.Players.Count;
        dealerMoved = false;

        while (!bettingComplete)
        {
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
                    drawer.ActivateButtons(gameStateService.ButtonsField, dealerMoved);
                    playerMoveTcs = new TaskCompletionSource<bool>();
                    playerMoveTcs = new TaskCompletionSource<bool>();
                    await playerMoveTcs.Task;
                    drawer.DeactivateButtons(gameStateService.ButtonsField);
                }
                if(currentPlayer.IsDealer)
                {
                    dealerMoved = true;
                }
            }
            bettingComplete = CheckBettingComplete();
            currentPlayerIndex = (currentPlayerIndex + 1) % gameStateService.Players.Count;
        }
    }
    public void PlayerMadeMove()
    {
        playerMoveTcs?.TrySetResult(true); 
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
            var action = random.Next(0, 100);

            if (action < 60)
            {
                playerService.Call(bot);
            }
            else if (action < 80 && !dealerMoved)
            {
                var raiseAmount = random.Next(1, bot.Stack / 6);
                playerService.Bet(bot, raiseAmount);
            }
            else
            {
                playerService.Fold(bot);
            }
        }
    }

    private bool CheckBettingComplete()
    {
        int highestBet = gameStateService.Players.Max(p => p.CurrentBet);
        return gameStateService.Players.All(p => p.IsFolded || p.IsAllIn || p.CurrentBet == highestBet && dealerMoved);
    }
}
