using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteroidGame.WebAPI.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
