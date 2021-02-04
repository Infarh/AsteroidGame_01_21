using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AsteroidGame.WebAPI.Data;
using AsteroidGame.WebAPI.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AsteroidGame.WebAPI.Controllers
{
    [Route("api/[controller]")] //api/players
    [ApiController]
    public class Players : ControllerBase
    {
        private readonly AsteroidGameDB _db;
        private readonly ILogger<Players> _Logger;

        public Players(AsteroidGameDB db, ILogger<Players> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        [HttpGet] // api/players
        public IEnumerable<Player> GetAllPlayers()
        {
            _Logger.LogInformation("Запрос всех игроков");

            return _db.Players.ToArray();
        }

        [HttpGet("initialize")] //api/players/initialize
        public void Initialize()
        {
            _Logger.LogInformation("Запрос инициализации тестовых данных");


            if (_db.Players.Any())
            {
                _Logger.LogInformation("Запрос инициализации тестовых данных - не требуется");
                return;
            }

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
            _Logger.LogInformation("Тестовые данные добавлены в БД");

        }

        [HttpGet("game/{id}")] //api/players/game/5
        public IEnumerable<Game> GetPlayerGames(int id)
        {
            _Logger.LogInformation("Запрос данных по игроку id:{0}", id);


            var player = _db.Players.Include(p => p.Games).FirstOrDefault(p => p.Id == id);
            if (player is null)
            {
                _Logger.LogInformation("Игрок с id:{0} в БД не найден", id);
                return Enumerable.Empty<Game>();
            }

            foreach (var game in player.Games)
                game.Player = null;

            _Logger.LogInformation("Вывод данных по игроку id:{0}", id);
            return player.Games;
        }

        [HttpPost("add/{PlayerName}")] // api/players/add/Ivanov
        public Game AddGame(string PlayerName, [FromBody] int Scores)
        {
            _Logger.LogInformation("Добавление даных по игре для {0} - число набранных очков {1}", PlayerName, Scores);

            var player = _db.Players.FirstOrDefault(p => p.Name == PlayerName);
            if (player is null)
                player = new Player
                {
                    Name = PlayerName
                };

            var game = new Game
            {
                Player = player,
                Scores = Scores
            };

            _db.Games.Add(game);
            _db.SaveChanges();

            _Logger.LogInformation("Данные поб игре для {0} доабвлены с id:{1}", PlayerName, game.Id);

            game.Player = null;
            return game;
        }
    }
}
