using Poker.Entity;
using PokerTry2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTry2.Services
{
    internal class FormFinder
    {
        public Control FindControlWithTag(Control parent, string tag)
        {
            var foundControls = parent.Controls.Find(tag, true);
            return foundControls.FirstOrDefault();
        }

        public Control[] FindControlsWithTag(Control parent, string tag)
        {
            var foundControls = parent.Controls.Find(tag, true);
            return foundControls.ToArray();
        }

        public UserControl FindHand(Player player, Panel field)
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
