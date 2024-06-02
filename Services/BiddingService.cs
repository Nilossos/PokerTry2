//using Poker.Entity;

//namespace Poker1.Services
//{
//    public interface IBiddingService
//    {
//        // public void StartGame();
//        public void PlaceBet(Player player, int amount);
//    }

//    public class BiddingService : IBiddingService
//    {
//        public void PlaceBet(Player player, int amount)
//        {
//            if (player == null || amount == 0) return;

//            // Управление состоянием игрока и игры
//            player.Stack -= amount;
//            player.CurrentBet += amount;
//            _gameStateService.CurrentBet = player.CurrentBet;
//            _gameStateService.Pot += amount;
//            _hubContext.Clients.All.SendAsync("UpdateGame",
//                new { PlayerId = player.Id, Amount = amount, TimeStamp = DateTime.UtcNow, _gameStateService.Pot });
//        }
//    }
//}