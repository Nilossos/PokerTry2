// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Caching.Memory;
// using Newtonsoft.Json;
// using Poker.Entity;
// using Poker1.Models;
// using Poker1.Services;
// using System;
//
// // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//
// namespace Poker1.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class DealController : ControllerBase
//     {
//         private readonly IGameStateService _gameStateService;
//         private readonly IDealService _dealService;
//
//         public DealController(IGameStateService gameStateService, IDealService dealService)
//         {
//             _gameStateService = gameStateService;
//             _dealService = dealService;
//         }
//
//         [HttpPost("Reset")]
//         public ActionResult<string> Reset()
//         {
//             _gameStateService.Reset();
//             return Ok("Game state has been reset.");
//         }
//         
//         [HttpGet("AssignDealer")]
//         public ActionResult<string> AssignDealer()
//         {
//             try
//             {
//                 var dealerName = _dealService.AssignDealer();
//                 return Ok(_gameStateService.Players);
//             }
//             catch (InvalidOperationException ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//
//         [HttpGet("CollectAnte/{ante}")]
//         public IActionResult CollectAnte(int ante)
//         {
//             try
//             {
//                 _dealService.CollectAnte(ante);
//                 return Ok(_gameStateService.Players);
//             }
//             catch (ArgumentException ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//
//         [HttpGet("DealCards")]
//         public ActionResult<IEnumerable<Card>> DealCards()
//         {
//             try
//             {
//                 var Cards = _dealService.DealCards();
//                 return Ok(Cards);
//             }
//             catch (ArgumentException ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//     }
// }
