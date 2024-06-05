using Poker.Entity;
using Poker1.Models;
using Poker1.Services;
using PokerTry2;
using PokerTry2.Models;
using PokerTry2.Services;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

public class DealController
{
    private readonly IGameStateService gameStateService;
    private readonly IDealService dealService;
    public DealController(IGameStateService gameStateService, IDealService dealService)
    {
        this.gameStateService = gameStateService;
        this.dealService = dealService;
    }

    public async Task StartDeal()
    {
        gameStateService.Update();
        dealService.StartDeal();
    }
}
