using SuperheroesUniverse.Data.Models;
using System;
using System.Linq;

namespace SuperheroesUniverse.Services
{
    public interface ISuperheroesService
    {
        IQueryable<Superhero> GetAll();

        IQueryable<Superhero> ManagementGetAll();

        Superhero GetById(Guid? id);

        int InsertSuperhero(Superhero superhero);

        int DeleteSuperhero(Guid? id);

        int RestoreSuperhero(Guid? id);

        IQueryable<Superhero> Search(string pattern);

        int UpdateSuperhero(Superhero superhero);
    }
}
