using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }

    class Game
    {
        public int Id { get; set; }

        public int Scores { get; set; }

        public DateTime Date { get; set; }
    }
}
