using SuperheroesUniverse.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.Data
{
    public interface ISuperheroesUniverseContext
    {
        IDbSet<Superhero> Superheroes { get; }
    }
}
