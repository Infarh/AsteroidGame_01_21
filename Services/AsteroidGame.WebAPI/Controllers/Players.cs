using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsteroidGame.WebAPI.Data;
using AsteroidGame.WebAPI.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsteroidGame.WebAPI.Controllers
{
    [Route("api/[controller]")] //api/players
    [ApiController]
    public class Players : ControllerBase
    {
        private readonly AsteroidGameDB _db;

        public Players(AsteroidGameDB db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Player> GetAllPlayers()
        {
            //return Enumerable.Range(1, 10)
            //   .Select(i => new Player
            //   {
            //       Id = i,
            //       Name = $"Игрок {i}",
            //       Games = Enumerable.Range(1, 10).Select(j => new Game
            //       {
            //           Id = i + j - 1,
            //           Scores = i + j * 100,
            //           Date = DateTime.Now
            //       }).ToArray()
            //   });

            return _db.Players.ToArray();
        }

        [HttpGet("initialize")] //api/players/initialize
        public void Initialize()
        {
            if(_db.Players.Any()) return;

            _db.Players.AddRange(Enumerable.Range(1, 10)
               .Select(i => new Player
               {
                   //Id = i,
                   Name = $"Игрок {i}",
                   Games = Enumerable.Range(1, 10).Select(j => new Game
                   {
                       //Id = i + j - 1,
                       Scores = i + j * 100,
                       Date = DateTime.Now
                   }).ToArray()
               }));
            _db.SaveChanges();
        }

        [HttpGet("game/{id}")] //api/players/game/5
        public IEnumerable<Game> GetPlayerGames(int id)
        {
            var player = _db.Players.Include(p => p.Games).FirstOrDefault(p => p.Id == id);
            if (player is null) return Enumerable.Empty<Game>();

            foreach (var game in player.Games)
                game.Player = null;

            return player.Games;
        }

    }
}
