//using Microsoft.AspNetCore.SignalR;
//using Poker.Models;

//namespace Poker1.Services
//{
//    public class BiddingHub : Hub
//    {
//        private readonly IPlayerActionService _playerActionService;
//        // private readonly IGameStateService _gameStateService;

//        public BiddingHub(IPlayerActionService playerActionService, IGameStateService gameStateService)
//        {
//            _playerActionService = playerActionService ?? throw new ArgumentNullException(nameof(playerActionService));
//            // _gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
//        }

//        public async Task SubmitPlayerMove(int playerId, string action, int amount)
//        {
//            await _playerActionService.ProcessPlayerMove(playerId, action, amount);
//        }
//    }
//}