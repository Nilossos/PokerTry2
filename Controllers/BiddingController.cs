// using Microsoft.AspNetCore.Mvc;
// using Poker.Models;
// using Poker1.Services;
//
// namespace Poker1.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class BiddingController : ControllerBase
//     {
//         private readonly IBettingRoundService _bettingRoundService;
//         
//         public BiddingController(IBettingRoundService bettingRoundService)
//         {
//             _bettingRoundService = bettingRoundService;
//         }
//
//         [HttpGet("Start")]
//         public IActionResult Start()
//         {
//             try
//             {
//                 _bettingRoundService.RunBettingRound();
//                 return Ok();
//             }
//             catch (ArgumentException ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//
//         // [HttpPost("PlaceBet")]
//         // public async Task<ActionResult> PlaceBet(Bet betData)
//         // {
//         //     if (betData == null)
//         //     {
//         //         return BadRequest("Invalid bet data");
//         //     }
//         //
//         //     switch (betData.Type)
//         //     {
//         //         case BetType.Fold:
//         //             _playerService.Fold(_gameStateService.Players.First());
//         //             break;
//         //         case BetType.Bet:
//         //             _playerService.Bet(_gameStateService.Players.First(), betData.Amount);
//         //             break;
//         //         case BetType.Call:
//         //             _playerService.Call(_gameStateService.Players.First());
//         //             break;
//         //         case BetType.Raise:
//         //             _playerService.Raise(_gameStateService.Players.First(), betData.Amount);
//         //             break;
//         //         case BetType.Check:
//         //             _playerService.Check(_gameStateService.Players.First());
//         //             break;
//         //         default:
//         //             break;
//         //     }
//         //     
//         //     return Ok(betData);
//         // }
//     }
//
//     
// }
