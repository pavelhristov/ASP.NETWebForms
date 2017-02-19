using SuperheroesUniverse.Data.Models;
using System;
using System.Linq;

namespace SuperheroesUniverse.Services
{
    public interface ISuperheroesService
    {
        IQueryable<Superhero> GetAll();

        Superhero GetById(Guid? id);

        IQueryable<Superhero> Search(string pattern);
    }
}
