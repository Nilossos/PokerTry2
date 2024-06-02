using Poker.Entity;
using Poker.Models;
using Poker1.Models;
using PokerTry2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerTry2.Services
{
    public interface IDrawer
    {
        void DrawDealerMark(Player player, Panel panel);
        void DrawCards(Player player, Panel panel);
        void DrawLastBets(List<Player> player, Panel panel);
        void DrawHands(Panel panel);
        void DrawStacks(List<Player> players, Panel field);
        void ActivateButtons(Panel field);
        void DeactivateButtons(Panel field);
        void ReloadPage(List<Player> players, int pot, Panel field);
        void DrawBetType(Player player, Panel field, BetType betType);
    }

    public class ObjectDrawer : IDrawer
    {
        private readonly CardImageProvider cardImageProvider;
        public ObjectDrawer()
        {
            cardImageProvider = new CardImageProvider();
        }
        public void DrawDealerMark(Player player, Panel panel)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player), "Player cannot be null");
            }

            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel), "Panel cannot be null");
            }

            var oldDealerMarks = FindControlsWithTag(panel, "DealerMark");

            foreach (PictureBox oldDealerMark in oldDealerMarks)
            {
                panel.Controls.Remove(oldDealerMark);
                oldDealerMark.Dispose();
            }

            PictureBox dealerMark = new PictureBox
            {
                Name = "DealerMark",
                Image = Properties.Resources.DealerMark,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Tag = "DealerMark"
            };

            UserControl hand = null;
            if (player.Position == PlayerPosition.BottomCenter)
            {
                hand = (BottomCenterHand)panel.Controls.Find("BottomCenterHand", true).First();
                AddToHand(hand, dealerMark, 4, 0);
            }
            if (player.Position == PlayerPosition.LeftCenter)
            {
                hand = (LeftCenterHand)panel.Controls.Find("LeftCenterHand", true).First();
                AddToHand(hand, dealerMark, 1, 4);
            }
            if (player.Position == PlayerPosition.TopLeft)
            {
                hand = (TopHand)panel.Controls.Find("TopLeftHand", true).First();
                AddToHand(hand, dealerMark, 4, 1);
            }
            if (player.Position == PlayerPosition.TopRight)
            {
                hand = (TopHand)panel.Controls.Find("TopRightHand", true).First();
                AddToHand(hand, dealerMark, 4, 1);
            }
            if (player.Position == PlayerPosition.RightCenter)
            {
                hand = (RightCenterHand)panel.Controls.Find("RightCenterHand", true).First();
                AddToHand(hand, dealerMark, 0, 4);
            }
        }

        public void DrawHands(Panel Field)
        {
            BottomCenterHand bottomCenterHand = new PokerTry2.BottomCenterHand();
            bottomCenterHand.Location = new Point(Field.Width / 2 - bottomCenterHand.Width / 2, Field.Height - bottomCenterHand.Height - 40);
            Field.Controls.Add(bottomCenterHand);

            LeftCenterHand leftCenterHand = new PokerTry2.LeftCenterHand();
            leftCenterHand.Location = new Point((100), Field.Height / 2 - leftCenterHand.Height / 2);
            Field.Controls.Add(leftCenterHand);

            TopHand topLeftHand = new PokerTry2.TopHand();
            topLeftHand.Location = new Point(Field.Width / 3 - topLeftHand.Width / 2, 60);
            topLeftHand.Name = "TopLeftHand";
            Field.Controls.Add(topLeftHand);

            TopHand topRightHand = new PokerTry2.TopHand();
            topRightHand.Location = new Point(Field.Width - Field.Width / 3 - topRightHand.Width / 2, 60);
            topRightHand.Name = "TopRightHand";
            Field.Controls.Add(topRightHand);

            RightCenterHand rightCenterHand = new PokerTry2.RightCenterHand();
            rightCenterHand.Location = new Point(Field.Width - rightCenterHand.Width - (100), Field.Height / 2 - rightCenterHand.Height / 2);
            Field.Controls.Add(rightCenterHand);
        }

        public void DrawStacks(List<Player> players, Panel field)
        {
            foreach (Player player in players)
            {
                DrawStack(player, field);
            }
        }

        public void DrawStack(Player player, Panel field)
        {
            UserControl hand = FindHand(player, field);
            Control label = FindControlWithTag(hand, "Stack");
            if(label is Label)
            {
                label = (Label)label;
                label.Text = "Stack: " + player.Stack.ToString();
            }
        }

        public void DrawPot(int pot, Panel field)
        {
            Control Pot = FindControlWithTag(field, "Pot");
            if (Pot is Label)
            {
                Pot = (Label)Pot;
                Pot.Text = "Pot: " + pot.ToString();
            }
        }

        public void DrawCards(Player player, Panel field)
        {
            for (int i = 0; i < player.Cards.Count; i++)
            {
                PictureBox pictureBox = cardImageProvider.CreateCardPictureBox(player.Cards[i], player, i);
                UserControl hand = FindHand(player, field);
                if (player.Position == PlayerPosition.BottomCenter)
                {
                    AddToHand(hand, pictureBox, i, 1);
                }
                if (player.Position == PlayerPosition.LeftCenter)
                {
                    AddToHand(hand, pictureBox, 0, i);
                }
                if (player.Position == PlayerPosition.TopLeft)
                {
                    AddToHand(hand, pictureBox, i, 0);
                }
                if (player.Position == PlayerPosition.TopRight)
                {
                    AddToHand(hand, pictureBox, i, 0);
                }
                if (player.Position == PlayerPosition.RightCenter)
                {
                    AddToHand(hand, pictureBox, 1, i);
                }
            }
        }

        public void ActivateButtons(Panel field)
        {
            Button bet = FindControlWithTag(field, "Bet") as Button;
            Button call = FindControlWithTag(field, "Call") as Button;
            Button fold = FindControlWithTag(field, "Fold") as Button;
            bet.Enabled = true;
            call.Enabled = true;
            fold.Enabled = true;
        }

        public void DeactivateButtons(Panel field)
        {
            Button bet = FindControlWithTag(field, "Bet") as Button;
            Button call = FindControlWithTag(field, "Call") as Button;
            Button fold = FindControlWithTag(field, "Fold") as Button;
            bet.Enabled = false;
            call.Enabled = false;
            fold.Enabled = false;
        }

        public void ReloadPage(List<Player> players, int pot, Panel field)
        {
            DrawStacks(players, field);
            DrawPot(pot, field);
            DrawLastBets(players, field);
        }

        public void DrawLastBets(List<Player> players, Panel field)
        {
            foreach (Player player in players)
            {
                DrawLastBet(player, field);
            }
        }

        public void DrawLastBet(Player player, Panel field)
        {
            UserControl hand = FindHand(player, field);
            Control LastBet = FindControlWithTag(hand, "LastBet");
            if (LastBet is Label)
            {
                LastBet = (Label)LastBet;
                LastBet.Text = "LastBet: " + player.CurrentBet.ToString();
            }
        }

        public void DrawBetType(Player player, Panel field, BetType betType)
        {
            UserControl hand = FindHand(player, field);
            Control BetType = FindControlWithTag(hand, "BetType");
            if (BetType is Label)
            {
                BetType = (Label)BetType;
                BetType.Text = betType.ToString();
            }
        }

        private void AddToHand(UserControl hand, PictureBox pictureBox, int column, int row)
        {
            if (hand != null)
            {
                TableLayoutPanel handPanel = (TableLayoutPanel)hand.Controls.Find("HandPanel", true).First();
                if (handPanel != null)
                {
                    handPanel.Controls.Add(pictureBox, column, row);
                }
            }
        }

        private void UpdateImageInPictureBox(Control hand, string pictureBoxName, Image newImage)
        {
            var foundControls = hand.Controls.Find(pictureBoxName, true);

            if (foundControls.Length > 0 && foundControls[0] is PictureBox pictureBox)
            {
                pictureBox.Image = newImage;
            }
            else
            {
                Console.WriteLine($"PictureBox с именем {pictureBoxName} не найден.");
            }
        }

        private Control FindControlWithTag(Control parent, string tag)
        {
            var foundControls = parent.Controls.Find(tag, true);
            return foundControls.FirstOrDefault();
        }

        private Control[] FindControlsWithTag(Control parent, string tag)
        {
            var foundControls = parent.Controls.Find(tag, true);
            return foundControls.ToArray();
        }

        private UserControl FindHand(Player player, Panel field)
        {
            UserControl hand = null;
            if (player.Position == PlayerPosition.BottomCenter)
            {
                hand = (BottomCenterHand)field.Controls.Find("BottomCenterHand", true).First();
            }
            if (player.Position == PlayerPosition.LeftCenter)
            {
                hand = (LeftCenterHand)field.Controls.Find("LeftCenterHand", true).First();
            }
            if (player.Position == PlayerPosition.TopLeft)
            {
                hand = (TopHand)field.Controls.Find("TopLeftHand", true).First();
            }
            if (player.Position == PlayerPosition.TopRight)
            {
                hand = (TopHand)field.Controls.Find("TopRightHand", true).First();
            }
            if (player.Position == PlayerPosition.RightCenter)
            {
                hand = (RightCenterHand)field.Controls.Find("RightCenterHand", true).First();
            }
            return hand;
        }

    }

}
