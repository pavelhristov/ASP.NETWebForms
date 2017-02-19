using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Data;

namespace SuperheroesUniverse.Services
{
    public class SuperheroesService : ISuperheroesService
    {
        private ISuperheroesUniverseContext superheroesUniverseContext;

        public SuperheroesService(ISuperheroesUniverseContext superheroesUniverseContext)
        {
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
