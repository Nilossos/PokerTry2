using Poker.Entity;
using Poker.Models;
using Poker1.Models;
using PokerTry2.Services;

namespace Poker1.Services;

public interface IResultService
{
    public void DeterminateResult();
}

public class ResultService : IResultService
{
    private readonly IGameStateService gameStateService;
    private readonly IDrawer drawer;
    private readonly IPlayerService playerService;
    private readonly PokerHandEvaluator handEvaluator;

    public ResultService(IGameStateService gameStateService, IDrawer drawer, IPlayerService playerService)
    {
        this.gameStateService = gameStateService;
        this.drawer = drawer;
        this.playerService = playerService;
        this.handEvaluator = new PokerHandEvaluator();
    }

    public async void DeterminateResult()
    {
        List<Player> players = gameStateService.Players.Where(p => !p.IsFolded).ToList();
        drawer.OpenCards(gameStateService.TableField);
        Dictionary<Player, HandRank> playerHands = new Dictionary<Player, HandRank>();

        foreach (var player in players)
        {
            HandRank bestHand = handEvaluator.EvaluateHand(player.Cards);
            playerHands[player] = bestHand;
        }

        var winningHand = playerHands.OrderByDescending(ph => ph.Value).FirstOrDefault();
        var winners = playerHands.Where(ph => ph.Value == winningHand.Value).Select(ph => ph.Key).ToList();
        var winnerNames = string.Join(", ", winners.Select(winner => winner.Name));
        DividePot(winners, gameStateService.Pot);
        drawer.ReloadPage(players, gameStateService.Pot, gameStateService.TableField);
        MessageBox.Show($"Winners: {winnerNames} with hand {winningHand.Value}");
        await HandleWinners(winners);
    }

    private Task HandleWinners(List<Player> winners)
    {
        return Task.CompletedTask;
    }

    private void DividePot(List<Player> winners, int pot)
    {
        if (winners == null || winners.Count == 0)
            throw new ArgumentException("Winners list cannot be null or empty");

        int share = pot / winners.Count;
        int remainder = pot % winners.Count;

        foreach (var winner in winners)
        {
            winner.Stack += share;
        }

        // В случае остатка добавляем его к стеку первого игрока из списка
        if (remainder > 0)
        {
            winners[0].Stack += remainder;
        }
    }
}