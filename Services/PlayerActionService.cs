//using Microsoft.AspNetCore.SignalR;
//using Poker.Entity;
//using Poker.Models;

//namespace Poker1.Services
//{
//    public record PlayerAction(int PlayerId, string Action, int Amount);
//    public interface IPlayerActionService
//    {
//        Task ProcessPlayerMove(int playerId, string action, int amount);
//        Task<PlayerAction> WaitForPlayerAction();
//    }

//    public class PlayerActionService : IPlayerActionService
//    {
//        private readonly IGameStateService _gameStateService;
//        private readonly IPlayerService _playerService;

//        private volatile TaskCompletionSource<PlayerAction> _playerActionTaskCompletionSource;

//        public PlayerActionService(IGameStateService gameStateService, IPlayerService playerService)
//        {
//            _gameStateService = gameStateService;
//            _playerService = playerService;
//        }

//        public async Task ProcessPlayerMove(int playerId, string action, int amount)
//        {
//            var player = _gameStateService.Players.First();
//            if (player == null) return;

//            switch (action.ToLower())
//            {
//                case "call":
//                    _playerService.Call(player);
//                    break;
//                case "check":
//                    _playerService.Check(player);
//                    break;
//                case "bet":
//                    _playerService.Bet(player, amount);
//                    break;
//                case "raise":
//                    _playerService.Raise(player, amount);
//                    break;
//                case "fold":
//                    _playerService.Fold(player);
//                    break;
//            }
//            _playerActionTaskCompletionSource?.TrySetResult(new PlayerAction(playerId, action, amount));
//        }

//        public Task<PlayerAction> WaitForPlayerAction()
//        {
//            _playerActionTaskCompletionSource = new TaskCompletionSource<PlayerAction>();
//            return _playerActionTaskCompletionSource.Task;
//        }
//    }
//}