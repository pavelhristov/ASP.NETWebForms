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

        public int DeleteSuperhero(Guid? id)
        {
            Superhero superhero = this.GetById(id);

            superhero.isDeleted = true;

            return this.superheroesUniverseContext.SaveChanges();
        }

        public IQueryable<Superhero> GetAll()
        {
            return this.superheroesUniverseContext.Superheroes.Where(sh => !sh.isDeleted);
        }

        public Superhero GetById(Guid? id)
        {
            Superhero superhero =  id.HasValue ? this.superheroesUniverseContext.Superheroes.Find(id) : null;
            if (superhero != null && !superhero.isDeleted)
            {
                return superhero;
            }

            return null;
        }

        public int InsertSuperhero(Superhero superhero)
        {
            this.superheroesUniverseContext.Superheroes.Add(superhero);
            return this.superheroesUniverseContext.SaveChanges();
        }

        public IQueryable<Superhero> ManagementGetAll()
        {
            return this.superheroesUniverseContext.Superheroes;
        }

        public int RestoreSuperhero(Guid? id)
        {
            Superhero superhero = id.HasValue ? this.superheroesUniverseContext.Superheroes.Find(id) : null; ;

            Guard.WhenArgument(superhero, nameof(superhero)).IsNull().Throw();

            superhero.isDeleted = false;

            return this.superheroesUniverseContext.SaveChanges();
        }

        public IQueryable<Superhero> Search(string pattern)
        {
            return this.superheroesUniverseContext.Superheroes
                .Where(sh => (sh.Name.ToLower().Contains(pattern) || sh.SecretIdentity.ToLower().Contains(pattern)) && (!sh.isDeleted));
        }

        public int UpdateSuperhero(Superhero superhero)
        {
            var entity = this.superheroesUniverseContext.Superheroes.Find(superhero.Id);
            if (entity == null)
            {
                return -1;
            }

            this.superheroesUniverseContext.Entry(entity).CurrentValues.SetValues(superhero);

            return this.superheroesUniverseContext.SaveChanges();
        }
    }
}
