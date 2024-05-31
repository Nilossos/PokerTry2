//using Poker.Entity;
//using Poker.Models;

//namespace Poker1.Services
//{
//    public interface IGameStateService
//    {
//        List<Player> Players { get; set; }
//        List<Bet> Bets { get; set; }
//        int Pot { get; set; }
//        int CurrentBet { get; set; }
//        void Reset();
//    }

//    public class GameStateService : IGameStateService
//    {
//        public List<Player> Players { get; set; }
//        public List<Bet> Bets { get; set; }
//        public int CurrentBet { get; set; }
//        public int Pot { get; set; }

//        public void Reset()
//        {
//            Players = new List<Player>() {
//                new Player("Игрок", true),
//                new Player("Бот 1"),
//                new Player("Бот 2"),
//                new Player("Бот 3"),
//                new Player("Бот 4")
//            };
//            Bets = new List<Bet>();
//            Pot = 0;
//            CurrentBet = 0;
//        }
//    }
//}
