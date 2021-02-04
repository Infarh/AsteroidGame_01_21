using System;

namespace AsteroidGame.WebAPI.Models
{
    public class Game
    {
        public int Id { get; set; }

        public int Scores { get; set; }

        public DateTime Date { get; set; }

        public Player Player { get; set; }
    }
}
