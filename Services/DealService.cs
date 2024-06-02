using Poker.Entity;
using Poker1.Models;
using Poker1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTry2.Services
{
    public interface IDealService
    {
        public void StartDeal();
    }

    internal class DealService : IDealService
    {
        private readonly IDrawer drawer;
        private readonly IGameStateService gameStateService;

        public DealService(IGameStateService gameStateService, IDrawer drawer)
        {
            this.drawer = drawer;
            this.gameStateService = gameStateService;
        }

        public void StartDeal()
        {
            InitializeHands();
            AssignDealer();
            CollectAnte(50);
            DealCards();
        }

        private void InitializeHands()
        {
            drawer.DrawHands(gameStateService.TableField);
            drawer.DrawStacks(gameStateService.Players, gameStateService.TableField);
        }

        private string AssignDealer()
        {
            if (gameStateService.Players.Count >= 2)
            {
                Player currentPlayer = gameStateService.Players.FirstOrDefault(p => p.IsDealer == true);
                Player nextPlayer = gameStateService.Players[(gameStateService.Players.IndexOf(currentPlayer) + 1) % gameStateService.Players.Count];

                currentPlayer.IsDealer = false;
                nextPlayer.IsDealer = true;
                drawer.DrawDealerMark(nextPlayer, gameStateService.TableField);
                return nextPlayer.Name;
            }
            else
            {
                throw new InvalidOperationException("Недостаточно игроков для смены дилера.");
            }
        }

        private void CollectAnte(int ante)
        {
            if (ante <= 0)
            {
                throw new ArgumentException("Ante must be a positive integer.", nameof(ante));
            }

            for (int i = gameStateService.Players.Count - 1; i >= 0; i--)
            {
                Player currentPlayer = gameStateService.Players[i];
                currentPlayer.Stack -= ante;
                gameStateService.Pot += ante;
                if (currentPlayer.Stack < 0)
                {
                    gameStateService.Players.RemoveAt(i);
                }
            }

            if (gameStateService.Players.Count == 1)
            {

            }
        }

        private void DealCards()
        {
            foreach (Player player in gameStateService.Players)
            {
                while (player.Cards.Count != 5)
                {
                    var card = gameStateService.Deck.GetCard();
                    player.Cards.Add(card);
                }
                drawer.DrawCards(player, gameStateService.TableField);
            }
        }
    }
}
