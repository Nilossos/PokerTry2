using PokerTry2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTry2.Models
{
    public class PlayerPosition
    {
        public static readonly PlayerPosition BottomCenter = new PlayerPosition(new Point(400, 420));
        public static readonly PlayerPosition LeftCenter = new PlayerPosition(new Point(75, 175));
        public static readonly PlayerPosition TopLeft = new PlayerPosition(new Point(275, 45));
        public static readonly PlayerPosition TopRight = new PlayerPosition(new Point(650, 45));
        public static readonly PlayerPosition RightCenter = new PlayerPosition(new Point(950, 175));
        public Point Coordinates { get; private set; }

        private PlayerPosition(Point coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
