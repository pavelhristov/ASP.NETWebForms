using SuperheroesUniverse.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SuperheroesUniverse.Data
{
    public interface ISuperheroesUniverseContext : ISuperheroesUniverseBaseContext
    {
        IDbSet<Superhero> Superheroes { get; }
        DbEntityEntry Entry(object entity);
    }
}
