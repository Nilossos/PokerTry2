using Poker.Entity;
using Poker1.Models;
using Poker1.Services;
using PokerTry2.Controllers;
using PokerTry2.Models;
using System.Reflection;

namespace PokerTry2
{
    public partial class Form1 : Form
    {
        private readonly DealController dealController;
        private readonly BetController betController;
        private readonly IGameStateService gameStateService;

        public Form1(IGameStateService gameStateService, DealController dealController, BetController betController)
        {
            InitializeComponent();

            this.gameStateService = gameStateService;
            this.betController = betController;
            this.dealController = dealController;

            gameStateService.Reset(TableField, ButtonsField);
    
            dealController.StartDeal();
            betController.StartBets();
        }

        private void Bet_Click(object sender, EventArgs e)
        {
            betController.Bet(gameStateService.Players.First(), 100);
        }
        private void Call_Click(object sender, EventArgs e)
        {
            betController.Call(gameStateService.Players.First());
        }
        private void Fold_Click(object sender, EventArgs e)
        {
            betController.Fold(gameStateService.Players.First());
        }
    }
}
