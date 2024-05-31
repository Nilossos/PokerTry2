// using Microsoft.Extensions.Caching.Memory;
// using Newtonsoft.Json;
// using Poker.Entity;
//
// namespace Poker1.Models
// {
//     public class PlayerManager
//     {
//         private readonly IMemoryCache _cache;
//
//         public PlayerManager(IMemoryCache memoryCache)
//         {
//             _cache = memoryCache;
//         }
//
//         public List<Player> Players
//         {
//             get
//             {
//                 if (!_cache.TryGetValue("Players", out List<Player> players))
//                 {
//                     players = new List<Player>() {
//                 new Player("Игрок", true),
//                 new Player("Бот 1"),
//                 new Player("Бот 2"),
//                 new Player("Бот 3"),
//                 new Player("Бот 4")
//                 };
//
//                     _cache.Set("Players", players);
//                 }
//                 return players;
//             }
//             set
//             {
//                 _cache.Set("Players", value);
//                 //string serializedPlayers = JsonConvert.SerializeObject(value);
//                 //_cache.Set("Players", serializedPlayers);
//             }
//         }
//     }
// }
