using AsteroidGame.WebAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace AsteroidGame.WebAPI.Data
{
    public class AsteroidGameDB : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Game> Games { get; set; }

        public AsteroidGameDB(DbContextOptions<AsteroidGameDB> options) : base(options) { }
    }
}
