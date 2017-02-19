using SuperheroesUniverse.Data.Models;
using System.Linq;

namespace SuperheroesUniverse.MVP.Search
{
    public class SearchViewModel
    {
        public IQueryable<Superhero> Superheroes { get; set; }
    }
}
