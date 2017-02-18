using SuperheroesUniverse.Data.Models;
using System.Linq;

namespace SuperheroesUniverse.MVP.Superheroes
{
    public class SuperheroesViewModel
    {
        public IQueryable<Superhero> Superheroes { get; set; }
    }
}
