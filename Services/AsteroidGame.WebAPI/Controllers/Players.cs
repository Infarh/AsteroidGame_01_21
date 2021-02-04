using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AsteroidGame.WebAPI.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsteroidGame.WebAPI.Controllers
{
    [Route("api/[controller]")] //api/players
    [ApiController]
    public class Players : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Player> GetAllPlayers()
        {
            return Enumerable.Range(1, 10)
               .Select(i => new Player
               {
                   Id = i,
                   Name = $"Игрок {i}",
                   Games = Enumerable.Range(1, 10).Select(j => new Game
                   {
                       Id = i + j - 1,
                       Scores = i + j * 100,
                       Date = DateTime.Now
                   }).ToArray()
               });
        }

    }
}
