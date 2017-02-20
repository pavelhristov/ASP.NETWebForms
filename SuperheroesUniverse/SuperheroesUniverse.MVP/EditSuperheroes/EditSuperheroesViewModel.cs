using SuperheroesUniverse.Data.Models;
using System.Linq;

namespace SuperheroesUniverse.MVP.EditSuperheroes
{
    public class EditSuperheroesViewModel
    {
        public IQueryable<Superhero> Superheroes { get; set; }
    }
}
