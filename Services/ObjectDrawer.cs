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
        void ClearCards(Player player, Panel field);
        void DrawCards(Player player, Panel panel);
        void DrawLastBets(List<Player> player, Panel panel);
        void DrawLastBet(Player player, Panel panel);
        void DrawHands(Panel panel);
        void DrawStacks(List<Player> players, Panel field);
        void ActivateButtons(Panel field, bool dealerMoved = false);
        void DeactivateButtons(Panel field);
        void ActivateReplaceButton(Panel field);
        void DeactivateReplaceButton(Panel field);
        void ReloadPage(List<Player> players, int pot, Panel field);
        void DrawBetType(Player player, Panel field, BetType betType);
        void OpenCards(Panel panel);
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
            leftCenterHand.Location = new Point((100) + 20, Field.Height / 2 - leftCenterHand.Height / 2);
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
            rightCenterHand.Location = new Point(Field.Width - rightCenterHand.Width - (105), Field.Height / 2 - rightCenterHand.Height / 2);
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
            if (label is Label)
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

        public void ClearCards(Player player, Panel field)
        {
            UserControl hand = FindHand(player, field);
            TableLayoutPanel handPanel = FindControlWithTag(hand, "HandPanel") as TableLayoutPanel;
            for (int i = handPanel.Controls.Count - 1; i >= 0; i--)
            {
                Control control = handPanel.Controls[i];
                if (control is PictureBox pictureBox && pictureBox.Tag is Card)
                {
                    handPanel.Controls.Remove(control);
                    pictureBox.Dispose();
                }
            }
        }

        public void ClearLastBet(Player player, Panel field)
        {
            UserControl hand = FindHand(player, field);
            TableLayoutPanel handPanel = FindControlWithTag(hand, "HandPanel") as TableLayoutPanel;
            for (int i = handPanel.Controls.Count - 1; i >= 0; i--)
            {
                Control control = handPanel.Controls[i];
                if (control is PictureBox pictureBox && pictureBox.Tag is Card)
                {
                    handPanel.Controls.Remove(control);
                    pictureBox.Dispose();
                }
            }
        }

        public void DrawCards(Player player, Panel field)
        {
            UserControl hand = FindHand(player, field);
            TableLayoutPanel handPanel = hand.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
            for (int i = 0; i < player.Cards.Count; i++)
            {
                bool cardExists = false;

                foreach (Control control in handPanel.Controls)
                {
                    if (control is PictureBox existingPictureBox && existingPictureBox.Tag is Card existingCard)
                    {
                        if (existingCard.Equals(player.Cards[i]))
                        {
                            cardExists = true;
                            break;
                        }
                    }
                }

                if (!cardExists)
                {
                    PictureBox pictureBox = cardImageProvider.CreateCardPictureBox(player.Cards[i], player, i);
                    pictureBox.Tag = player.Cards[i];
                    if (player.Position == PlayerPosition.BottomCenter)
                    {
                        pictureBox.Click += (sender, e) =>
                        {
                            Card card = pictureBox.Tag as Card;
                            if (pictureBox.BorderStyle == BorderStyle.None)
                            {
                                pictureBox.BorderStyle = BorderStyle.Fixed3D; // Или любой другой стиль по вашему выбору
                            }
                            else
                            {
                                pictureBox.BorderStyle = BorderStyle.None;
                            }
                        };
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
        }

        public void ActivateButtons(Panel field, bool dealerMoved = false)
        {
            Button bet = FindControlWithTag(field, "Bet") as Button;
            Button call = FindControlWithTag(field, "Call") as Button;
            Button fold = FindControlWithTag(field, "Fold") as Button;
            if (!dealerMoved)
            {
                bet.Enabled = true;
                bet.BackColor = Color.White;
            }
            call.Enabled = true;
            call.BackColor = Color.White;
            fold.Enabled = true;
            fold.BackColor = Color.White;
        }

        public void DeactivateButtons(Panel field)
        {
            Button bet = FindControlWithTag(field, "Bet") as Button;
            Button call = FindControlWithTag(field, "Call") as Button;
            Button fold = FindControlWithTag(field, "Fold") as Button;
            bet.Enabled = false;
            bet.BackColor = Color.Gray;
            call.Enabled = false;
            call.BackColor = Color.Gray;
            fold.Enabled = false;
            fold.BackColor = Color.Gray;
        }

        public void ActivateReplaceButton(Panel field)
        {
            Button replaceButton = FindControlWithTag(field, "Replace") as Button;
            replaceButton.Enabled = true;
            replaceButton.BackColor = Color.White;
        }

        public void DeactivateReplaceButton(Panel field)
        {
            Button replaceButton = FindControlWithTag(field, "Replace") as Button;
            replaceButton.Enabled = false;
            replaceButton.BackColor = Color.Gray;
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

        public void OpenCards(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is UserControl handControl)
                {
                    TableLayoutPanel hand = (TableLayoutPanel)FindControlWithTag(handControl, "HandPanel");
                    PictureBox[] cardPictureBoxes = hand.Controls.OfType<PictureBox>()
                                                             .Where(pictureBox => pictureBox.Tag is Card)
                                                             .ToArray();
                    float angle = 0;
                    if (control is LeftCenterHand) angle = 90;
                    if (control is RightCenterHand) angle = -90;
                    if (control is TopHand) angle = 180;

                    foreach (PictureBox pictureBox in cardPictureBoxes)
                    {
                        Card card = (Card)pictureBox.Tag;
                        Image cardImage = cardImageProvider.GetCardImgage(card, angle);
                        pictureBox.Image = cardImage;
                    }
                }
            }
        }
    }

}
