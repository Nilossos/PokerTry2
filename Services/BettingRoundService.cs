//using Poker.Entity;

//namespace Poker1.Services;

//public interface IBettingRoundService
//{
//    public Task RunBettingRound();
//}

//public class BettingRoundService : IBettingRoundService
//{
//    private readonly IGameStateService _gameStateService;
//    private readonly IPlayerService _playerService;
//    private readonly IHubContext<BiddingHub> _hubContext;
//    private readonly IPlayerActionService _playerActionService;
    
//    public BettingRoundService(IGameStateService gameStateService, IPlayerService playerService,  IHubContext<BiddingHub> hubContext, IPlayerActionService playerActionService)
//    {
//        _playerService = playerService;
//        _gameStateService = gameStateService;
//        _playerActionService = playerActionService;
//        _hubContext = hubContext;
//    }

//    public async Task RunBettingRound()
//    {
//        bool bettingComplete = false;
//        List<Player> playersList = _gameStateService.Players;
//        int dealerIndex = playersList.FindIndex(p => p.DealerStatus);

//        while (!bettingComplete)
//        {
//            for (int i = 1; i <= playersList.Count; i++)
//            {
//                // Начинает игрок справа от дилера
//                int currentPlayerIndex = (dealerIndex + i) % playersList.Count;
//                Player currentPlayer = playersList[currentPlayerIndex];
//                if (!currentPlayer.IsFolded && !currentPlayer.IsAllIn)
//                {
//                    if (currentPlayer != _gameStateService.Players.First())
//                    {
//                        await Task.Delay(1500);
//                        await MakeBotMove(currentPlayer);
//                    }
//                    else
//                    {
//                        try
//                        {
//                            await RequestPlayerMove();
//                            var playerAction = await _playerActionService.WaitForPlayerAction();
//                            Console.WriteLine($"Player action received: {playerAction.PlayerId}, Action: {playerAction.Action}, Amount: {playerAction.Amount}");
//                        }
//                        catch (Exception ex)
//                        {
//                            Console.WriteLine($"Error waiting for player action: {ex.Message}");
//                        }
//                    }
//                }
//                bettingComplete = CheckBettingComplete();
//            }
//        }
//    }

//    private async Task RequestPlayerMove()
//    {
//        await _hubContext.Clients.All.SendAsync("RequestPlayerMove");
//    }
//    private async Task MakeBotMove(Player bot)
//    {
//        if (bot.Stack <= _gameStateService.CurrentBet)
//        {
//            _playerService.Call(bot);
//        }
//        else
//        {
//            var random = new Random();
//            var action = random.Next(1, 2); // 0 - call, 1 - raise, 2 - fold

//            switch (action)
//            {
//                case 0:
//                    _playerService.Call(bot);
//                    break;
//                case 1:
//                    var raiseAmount = random.Next(1, bot.Stack / 6);
//                    _playerService.Raise(bot, raiseAmount);
//                    break;
//                case 2:
//                    _playerService.Fold(bot);
//                    break;
//            }
//        }
//    }
//    private bool CheckBettingComplete()
//    {
//        // Условия завершения круга торговли:
//        // Все игроки сделали одинаковые ставки или все, кроме одного, сбросили карты
//        int highestBet = _gameStateService.Players.Max(p => p.CurrentBet);
//        return _gameStateService.Players.All(p => p.IsFolded || p.IsAllIn || p.CurrentBet == highestBet);
//    }
//}