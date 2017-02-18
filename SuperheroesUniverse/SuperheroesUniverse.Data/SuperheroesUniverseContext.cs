using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperheroesUniverse.Data.Models;

namespace SuperheroesUniverse.Data
{
    public class SuperheroesUniverseContext : DbContext, ISuperheroesUniverseContext
    {
        public SuperheroesUniverseContext()
            : base("SuperheroesUniverseDb")
        {

        }

        public IDbSet<Superhero> Superheroes { get; set; }
    }
}
