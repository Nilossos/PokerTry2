using Poker.Entity;
using Poker1.Models;
using PokerTry2.Services;

namespace Poker1.Services;

public interface IReplacementService
{
    public Task RunReplacementRound();
    public void PlayerMadeMove();
}

public class ReplacementService : IReplacementService
{
    private readonly IGameStateService gameStateService;
    private readonly IDrawer drawer;
    private readonly IPlayerService playerService;
    private TaskCompletionSource<bool> playerMoveTcs;

    public ReplacementService(IGameStateService gameStateService, IDrawer drawer, IPlayerService playerService)
    {
        this.gameStateService = gameStateService;
        this.drawer = drawer;
        this.playerService = playerService;
    }

    public async Task RunReplacementRound()
    {
        bool dealerMoved = false;
        drawer.DeactivateButtons(gameStateService.ButtonsField);
        int dealerIndex = gameStateService.Players.FindIndex(p => p.IsDealer);
        int currentPlayerIndex = (dealerIndex + 1) % gameStateService.Players.Count;

        while (!dealerMoved)
        {
            Player currentPlayer = gameStateService.Players[currentPlayerIndex];
            if (!currentPlayer.IsFolded)
            {
                if (currentPlayer != gameStateService.Players.First())
                {
                    await MakeBotMove(currentPlayer);
                }
                else
                {
                    drawer.ActivateReplaceButton(gameStateService.ButtonsField);
                    playerMoveTcs = new TaskCompletionSource<bool>();
                    await playerMoveTcs.Task;
                    drawer.DeactivateReplaceButton(gameStateService.ButtonsField);
                }
            }
            if (currentPlayer.IsDealer)
            {
                dealerMoved = true;
            }
            currentPlayerIndex = (currentPlayerIndex + 1) % gameStateService.Players.Count;
        }
    }

    public void PlayerMadeMove()
    {
        playerMoveTcs?.TrySetResult(true);
    }

    private async Task MakeBotMove(Player bot)
    {
        //FIXME ОПТИМИЗИРОВАТЬ
        var random = new Random();
        int numberOfCardsToReplace = random.Next(0, 6);
        List<Card> cardsToReplace = new List<Card>();
        HashSet<int> chosenIndices = new HashSet<int>();
        for (int i = 0; i < numberOfCardsToReplace; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = random.Next(0, bot.Cards.Count);
            } while (chosenIndices.Contains(randomIndex));
            chosenIndices.Add(randomIndex);
            cardsToReplace.Add(bot.Cards[randomIndex]);
        }
        await playerService.Replace(bot, cardsToReplace);
    }
}
