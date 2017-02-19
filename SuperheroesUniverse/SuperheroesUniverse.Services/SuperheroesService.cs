using System;
using System.Linq;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Data;
using Bytes2you.Validation;

namespace SuperheroesUniverse.Services
{
    public class SuperheroesService : ISuperheroesService
    {
        private ISuperheroesUniverseContext superheroesUniverseContext;

        public SuperheroesService(ISuperheroesUniverseContext superheroesUniverseContext)
        {
            Guard.WhenArgument(superheroesUniverseContext, nameof(superheroesUniverseContext)).IsNull().Throw();

            this.superheroesUniverseContext = superheroesUniverseContext;
        }

        public IQueryable<Superhero> GetAll()
        {
            return this.superheroesUniverseContext.Superheroes;
        }

        public Superhero GetById(Guid? id)
        {
            return id.HasValue ? this.superheroesUniverseContext.Superheroes.Find(id) : null;
        }

        public IQueryable<Superhero> Search(string pattern)
        {
            return this.superheroesUniverseContext.Superheroes
                .Where(sh => sh.Name.ToLower().Contains(pattern) || sh.SecretIdentity.ToLower().Contains(pattern));
        }
    }
}
