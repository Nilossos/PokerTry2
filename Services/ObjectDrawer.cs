using Poker.Entity;
using Poker1.Models;
using PokerTry2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerTry2.Services
{
    public interface IDrawer
    {
        void DrawDealerMark(Player player, Panel panel);
        void DrawCards(Player player, Panel panel);
        void DrawHands(Panel panel);
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

            PictureBox[] oldDealerMarks = FindControlsWithTag(panel, "DealerMark") as PictureBox[];

            foreach(PictureBox oldDealerMark in oldDealerMarks)
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
            leftCenterHand.Location = new Point(40, Field.Height / 2 - leftCenterHand.Height / 2);
            Field.Controls.Add(leftCenterHand);

            TopHand topLeftHand = new PokerTry2.TopHand();
            topLeftHand.Location = new Point(Field.Width / 3 - topLeftHand.Width / 2, 40);
            topLeftHand.Name = "TopLeftHand";
            Field.Controls.Add(topLeftHand);

            TopHand topRightHand = new PokerTry2.TopHand();
            topRightHand.Location = new Point(Field.Width - Field.Width / 3 - topRightHand.Width / 2, 40);
            topRightHand.Name = "TopRightHand";
            Field.Controls.Add(topRightHand);

            RightCenterHand rightCenterHand = new PokerTry2.RightCenterHand();
            rightCenterHand.Location = new Point(Field.Width - rightCenterHand.Width - 60, Field.Height / 2 - rightCenterHand.Height / 2);
            Field.Controls.Add(rightCenterHand);
        }



        public async void DrawCards(Player player, Panel panel)
        {
            for (int i = 0; i < player.Cards.Count; i++)
            {
                PictureBox pictureBox = cardImageProvider.CreateCardPictureBox(player.Cards[i], player, i);
                UserControl hand = null;
                if (player.Position == PlayerPosition.BottomCenter)
                {
                    hand = (BottomCenterHand)panel.Controls.Find("BottomCenterHand", true).First();
                    AddToHand(hand, pictureBox, i, 1);
                }
                if (player.Position == PlayerPosition.LeftCenter)
                {
                    hand = (LeftCenterHand)panel.Controls.Find("LeftCenterHand", true).First();
                    AddToHand(hand, pictureBox, 0, i);
                }
                if (player.Position == PlayerPosition.TopLeft)
                {
                    hand = (TopHand)panel.Controls.Find("TopLeftHand", true).First();
                    AddToHand(hand, pictureBox, i, 0);
                }
                if (player.Position == PlayerPosition.TopRight)
                {
                    hand = (TopHand)panel.Controls.Find("TopRightHand", true).First();
                    AddToHand(hand, pictureBox, i, 0);
                }
                if (player.Position == PlayerPosition.RightCenter)
                {
                    hand = (RightCenterHand)panel.Controls.Find("RightCenterHand", true).First();
                    AddToHand(hand, pictureBox, 1, i);
                }
                await Task.Delay(500);
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

        public void UpdateImageInPictureBox(Control hand, string pictureBoxName, Image newImage)
        {
            var foundControls = hand.Controls.Find(pictureBoxName, true);

            if (foundControls.Length > 0 && foundControls[0] is PictureBox pictureBox)
            {
                pictureBox.Image = newImage;
            }
            else
            {
                // Обработка случая, если PictureBox не найден
                Console.WriteLine($"PictureBox с именем {pictureBoxName} не найден.");
            }
        }

        public Control FindControlWithTag(Control parent, string tag)
        {
            var foundControls = parent.Controls.Find(tag, true);

            return foundControls.OfType<PictureBox>().FirstOrDefault();
        }

        public PictureBox[] FindControlsWithTag(Control parent, string tag)
        {
            var foundControls = parent.Controls.Find(tag, true);

            var pictureBoxes = foundControls.OfType<PictureBox>().ToArray();

            return pictureBoxes;
        }
    }

}
