//using Poker.Entity;

//namespace Poker1.Services;

//public interface IPlayerService
//{
//    public void Call(Player player);
//    public void Check(Player player);
//    public void Bet(Player player, int betAmount);
//    public void Raise(Player player, int raiseAmount);
//    public void Fold(Player player);
//}

//public class PlayerService : IPlayerService
//{
//    private readonly IGameStateService _gameStateService;
//    private readonly IBiddingService _biddingService;

//    public PlayerService(IGameStateService gameStateService, IBiddingService biddingService)
//    {
//        _gameStateService = gameStateService;
//        _biddingService = biddingService;
//    }

//    public void Call(Player player)
//    {
//        if (player == null || player.IsFolded || player.IsAllIn) return;

//        var amountToCall = _gameStateService.CurrentBet - player.CurrentBet;
//        _biddingService.PlaceBet(player, amountToCall);
//    }

//    public void Check(Player player)
//    {
//        if (player == null || player.IsFolded || player.IsAllIn) return;
//        _biddingService.PlaceBet( player, 0);
//    }

//    public void Bet(Player player, int betAmount)
//    {
//        if (player == null || player.IsFolded || player.IsAllIn) return;
//        var amountToBet = _gameStateService.CurrentBet - player.CurrentBet + betAmount;
//        _biddingService.PlaceBet(player, amountToBet);
//    }

//    public void Raise(Player player, int raiseAmount)
//    {
//        if (player == null || player.IsFolded || player.IsAllIn) return;
//        var amountToRaise = _gameStateService.CurrentBet - player.CurrentBet + raiseAmount;
//        _biddingService.PlaceBet(player, amountToRaise);
//    }

//    public void Fold(Player player)
//    {
//        player.IsFolded = true;
//        _biddingService.PlaceBet(player,0);
//    }
//    // Другие методы для управления состоянием игрока
//}






