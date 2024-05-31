using Poker.Entity;
using Poker1.Models;
using PokerTry2;
using PokerTry2.Models;
using PokerTry2.Services;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

public class GameController
{
    private readonly IDrawer drawer;
    public List<Player> Players { get; private set; }
    public Deck Deck { get; private set; }
    protected Control Field { get; private set; }
    public GameController(Control panel1)
    {
        drawer = new ObjectDrawer();
        Deck = new Deck();
        Field = panel1;
        InitializePlayers();
        InitializeHands();
    }

    private void InitializePlayers()
    {
        Players = new List<Player>
        {
            new Player("Игрок", PlayerPosition.BottomCenter, true),
            new Player("Бот 1", PlayerPosition.LeftCenter),
            new Player("Бот 2", PlayerPosition.TopLeft),
            new Player("Бот 3", PlayerPosition.TopRight),
            new Player("Бот 4", PlayerPosition.RightCenter)
        };
    }

    private void InitializeHands()
    {
        drawer.DrawHands(Field as Panel);
    }

    public string AssignDealer(Panel panel)
    {
        if (Players.Count >= 2)
        {
            Player currentPlayer = Players.FirstOrDefault(p => p.IsDealer == true);
            Player nextPlayer = Players[(Players.IndexOf(currentPlayer) + 1) % Players.Count];

            currentPlayer.IsDealer = false;
            nextPlayer.IsDealer = true;
            drawer.DrawDealerMark(nextPlayer, panel);
            return nextPlayer.Name;
        }
        else
        {
            throw new InvalidOperationException("Недостаточно игроков для смены дилера.");
        }
    }

    public void CollectAnte(int ante)
    {
        if (ante <= 0)
        {
            throw new ArgumentException("Ante must be a positive integer.", nameof(ante));
        }

        for (int i = Players.Count - 1; i >= 0; i--)
        {
            Player currentPlayer = Players[i];
            currentPlayer.Stack -= ante;
            if (currentPlayer.Stack < 0)
            {
                Players.RemoveAt(i);
            }
        }

        if (Players.Count == 1)
        {

        }
    }

    public async void DealCards(Panel panel)
    {
        foreach (Player player in Players)
        {
            while (player.Cards.Count != 5)
            {
                var card = Deck.getCard();
                player.Cards.Add(card);
            }
            drawer.DrawCards(player, panel);
        }
    }
}
