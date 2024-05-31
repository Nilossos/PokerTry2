using Poker.Entity;
using Poker1.Models;
using System.Reflection;

namespace PokerTry2
{
    public partial class Form1 : Form
    {
        private readonly GameController gameController;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            gameController = new GameController(panel1);
            StartDeal();
        }

        private void StartDeal()
        {
            gameController.AssignDealer(panel1);
            gameController.CollectAnte(50);
            gameController.DealCards(panel1);
        }
    }
}
