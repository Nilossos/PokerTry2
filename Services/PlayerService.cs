using Poker.Entity;
using Poker.Models;
using PokerTry2.Services;

namespace Poker1.Services
{
    public interface IPlayerService
    {
        void Call(Player player);
        void Bet(Player player, int betAmount);
        //void Raise(Player player, int raiseAmount);
        void Fold(Player player);
    }

    public class PlayerService : IPlayerService
    {
        private readonly IDrawer drawer;
        private readonly IGameStateService gameStateService;

        public PlayerService(IGameStateService gameStateService, IDrawer drawer)
        {
            this.drawer = drawer;
            this.gameStateService = gameStateService;
        }

        public void Call(Player player)
        {
            if (player == null || player.IsFolded || player.IsAllIn) return;

            var amountToCall = gameStateService.CurrentGlobalBet - player.CurrentBet;
            PlaceBet(player, amountToCall);
            if (gameStateService.CurrentGlobalBet == 0)
            {
                drawer.DrawBetType(player, gameStateService.TableField, BetType.Check);
            }
            else
            {
                drawer.DrawBetType(player, gameStateService.TableField, BetType.Call);
            }
        }

        public void Bet(Player player, int betAmount)
        {
            if (player == null || player.IsFolded || player.IsAllIn) return;
            var amountToBet = gameStateService.CurrentGlobalBet - player.CurrentBet + betAmount;
            drawer.DrawBetType(player, gameStateService.TableField, BetType.Bet);
            if (gameStateService.CurrentGlobalBet == 0)
            {
                drawer.DrawBetType(player, gameStateService.TableField, BetType.Bet);
            }
            else
            {
                drawer.DrawBetType(player, gameStateService.TableField, BetType.Raise);
            }
            PlaceBet(player, amountToBet);
        }

        public void Fold(Player player)
        {
            player.IsFolded = true;
            PlaceBet(player, 0);
            drawer.DrawBetType(player, gameStateService.TableField, BetType.Fold);
        }

        public void PlaceBet(Player player, int amount)
        {
            if (player == null || amount == 0) return;

            // Управление состоянием игрока и игры
            player.Stack -= amount;
            player.CurrentBet += amount;
            gameStateService.CurrentGlobalBet = player.CurrentBet;
            gameStateService.Pot += amount;
            drawer.ReloadPage(gameStateService.Players, gameStateService.Pot, gameStateService.TableField);
        }
    }
}