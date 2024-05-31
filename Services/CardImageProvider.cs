using Poker.Entity;
using Poker1.Models;
using PokerTry2.Models;
using System.Drawing;
using System.Reflection;

namespace PokerTry2.Services
{
    public class CardImageProvider
    {
        private readonly string projectRootPath;

        public CardImageProvider()
        {
            projectRootPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))));
        }

        public PictureBox CreateCardPictureBox(Card card, Player player, int cardNumber)
        {
            PictureBox pictureBox = new PictureBox
            {
                Width = 72,
                Height = 96,
                Image = player.Name == "Игрок" ? card.Image : Properties.Resources.Card_Back_88x124,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            if (player.Position == PlayerPosition.TopLeft || player.Position == PlayerPosition.TopRight)
            {
                RotateImage(pictureBox, 180);
            }
            if (player.Position == PlayerPosition.LeftCenter)
            {
                RotateImage(pictureBox, 90);
            }
            else if(player.Position == PlayerPosition.RightCenter)
            {
                RotateImage(pictureBox, -90);
            }
            return pictureBox;
        }

        public void OpenCards(Player player)
        {
            foreach (Card card in player.Cards)
            {
                PictureBox pictureBox = FindPictureBoxForCard(card);
                if (pictureBox != null)
                {
                    RotateImage(pictureBox, 0);
                }
            }
        }

        private PictureBox FindPictureBoxForCard(Card card)
        {
            return null;
        }

        private void RotateImage(PictureBox pictureBox, float angle)
        {
            if (pictureBox.Image == null)
                return;

            Image originalImage = pictureBox.Image;

            // Для поворота на 180 градусов не меняем размер изображения
            if (Math.Abs(angle - 180) < float.Epsilon)
            {
                originalImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pictureBox.Image = originalImage;
                return;
            }

            double angleRadians = angle * Math.PI / 180;
            double cos = Math.Abs(Math.Cos(angleRadians));
            double sin = Math.Abs(Math.Sin(angleRadians));

            int originalWidth = originalImage.Width;
            int originalHeight = originalImage.Height;

            int newWidth = (int)(originalWidth * cos + originalHeight * sin);
            int newHeight = (int)(originalWidth * sin + originalHeight * cos);

            Bitmap rotatedImage = new Bitmap(newWidth, newHeight);
            rotatedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform((float)newWidth / 2, (float)newHeight / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-(float)originalWidth / 2, -(float)originalHeight / 2);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, new Point(0, 0));
            }

            pictureBox.Image = rotatedImage;
            var tmp = pictureBox.Width;
            pictureBox.Width = pictureBox.Height;
            pictureBox.Height = tmp;
        }
    }
}
