using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseManagment.Data
{
    class PlayersDB : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<GameSession> GameSessions { get; set; }

        public PlayersDB(DbContextOptions<PlayersDB> options) : base(options) { }
    }

    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GameSession> Sessions { get; set; }
    }

    public class GameSession
    {
        //[Key]
        public int Id { get; set; }

        public int Scores { get; set; }

        public Player Player { get; set; }
    }
}
