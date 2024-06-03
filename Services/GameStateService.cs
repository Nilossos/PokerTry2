using Poker.Entity;
using Poker.Models;
using Poker1.Models;
using PokerTry2.Models;
using PokerTry2.Services;

namespace Poker1.Services
{
    public interface IGameStateService
    {
        List<Player> Players { get; }
        Deck Deck { get; }
        int Pot { get; set; }
        int CurrentGlobalBet { get; set; }
        Panel TableField { get; }
        Panel ButtonsField { get;}
        void Create(Panel tableField, Panel buttonsField);
        void Update();
    }

    public class GameStateService : IGameStateService
    {
        public List<Player> Players { get; private set; }
        public Deck Deck { get; private set; }
        public int Pot { get; set; }
        public int CurrentGlobalBet { get; set; }
        public Panel TableField { get; private set; }
        public Panel ButtonsField { get; private set; }

        public void Create(Panel tableField, Panel buttonsField)
        {
            Players = new List<Player>() {
                new Player("Игрок", PlayerPosition.BottomCenter, true),
                new Player("Бот 1", PlayerPosition.LeftCenter),
                new Player("Бот 2", PlayerPosition.TopLeft),
                new Player("Бот 3", PlayerPosition.TopRight),
                new Player("Бот 4", PlayerPosition.RightCenter)
            };
            Pot = 0;
            CurrentGlobalBet = 0;
            Deck = new Deck();
            TableField = tableField;
            ButtonsField = buttonsField;
        }

        public void Update()
        {
            Pot = 0;
            CurrentGlobalBet = 0;
            Deck = new Deck();
        }
    }
}
