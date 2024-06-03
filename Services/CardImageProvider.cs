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
                RotatePictureBox(pictureBox, 180);
            }
            if (player.Position == PlayerPosition.LeftCenter)
            {
                RotatePictureBox(pictureBox, 90);
            }
            else if(player.Position == PlayerPosition.RightCenter)
            {
                RotatePictureBox(pictureBox, -90);
            }
            return pictureBox;
        }

        public Image GetCardImgage(Card card, float angle)
        {
            Image cardImage = card.Image;
            cardImage = RotateImage(cardImage, angle);
            return cardImage;
        }

        private void RotatePictureBox(PictureBox pictureBox, float angle)
        {
            Image originalImage = pictureBox.Image;

            // Поворачиваем изображение
            Image rotatedImage = RotateImage(originalImage, angle);

            // Обновляем изображение в PictureBox
            pictureBox.Image = rotatedImage;

            // Меняем ширину и высоту PictureBox местами
            var tmp = pictureBox.Width;
            pictureBox.Width = pictureBox.Height;
            pictureBox.Height = tmp;
        }

        private Image RotateImage(Image originalImage, float angle)
        {
            // Проверяем, что изображение не пусто
            if (originalImage == null)
                return null;

            // Для поворота на 180 градусов не меняем размер изображения
            if (Math.Abs(angle - 180) < float.Epsilon)
            {
                originalImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                return originalImage;
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

            return rotatedImage;
        }
    }
}
