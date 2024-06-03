using Poker.Entity;
using Poker1.Models;
using Poker1.Services;
using PokerTry2.Controllers;
using PokerTry2.Models;
using PokerTry2.Properties;
using PokerTry2.Services;
using System.Reflection;

namespace PokerTry2
{
    public partial class Poker : Form
    {
        private readonly DealController dealController;
        private readonly BetController betController;
        private readonly ReplacementController replacementController;
        private readonly ResultController resultController;
        private readonly IGameStateService gameStateService;
        private readonly Player player;

        public Poker(IGameStateService gameStateService, DealController dealController, BetController betController, ReplacementController replacementController, ResultController resultController)
        {
            InitializeComponent();

            this.gameStateService = gameStateService;
            this.betController = betController;
            this.dealController = dealController;
            this.replacementController = replacementController;
            this.resultController = resultController;
            gameStateService.Create(TableField, ButtonsField);

            StartGame();

            player = gameStateService.Players.Find(p => p.Position == PlayerPosition.BottomCenter);
        }

        private async void StartGame()
        {
            while (gameStateService.Players.Count != 1)
            {
                await dealController.StartDeal();
                await betController.StartBets();
                await replacementController.StartReplacements();
                await resultController.DeterminateResult();
                gameStateService.Update();
            }
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

        private void Increase_Click(object sender, EventArgs e)
        {
            if (int.TryParse(BetAmount.Text, out int value))
            {
                value++;
                BetAmount.Text = value.ToString();
            }
        }

        private void Decrease_Click(object sender, EventArgs e)
        {
            if (int.TryParse(BetAmount.Text, out int value))
            {
                value--;
                BetAmount.Text = value.ToString();
            }
        }

        private void BetAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешить только ввод цифр и клавиш Backspace и Delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void Replace_Click(object sender, EventArgs e)
        {
            List<PictureBox> pictureBoxesToReplace = new List<PictureBox>();
            FormFinder formFinder = new FormFinder();
            UserControl hand = formFinder.FindHand(player, TableField);
            Control handPanel = formFinder.FindControlWithTag(hand, "HandPanel");
            if (handPanel is TableLayoutPanel)
            {
                handPanel = (TableLayoutPanel)handPanel;
                foreach (Control control in handPanel.Controls)
                {
                    if (control is PictureBox pictureBox && pictureBox.BorderStyle == BorderStyle.Fixed3D)
                    {
                        pictureBoxesToReplace.Add(pictureBox);
                    }
                }
            }
            List<Card> cardsToReplace = new List<Card>();
            foreach (PictureBox pictureBox in pictureBoxesToReplace)
            {
                Card card = pictureBox.Tag as Card;
                if (card != null)
                {
                    cardsToReplace.Add(card);
                }
            }
            await replacementController.Replace(player, cardsToReplace);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Resources.table11;
            pictureBox.Width = 100;
            pictureBox.Height = 200;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(pictureBox);
            TableField.Controls.Add(pictureBox);
        }
    }
}
