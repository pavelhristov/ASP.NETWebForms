using System;
using WebFormsMvp;

namespace SuperheroesUniverse.MVP.Superheroes
{
    public interface ISuperheroesView: IView<SuperheroesViewModel>
    {
        event EventHandler OnSuperheroesGetData;
    }
}
