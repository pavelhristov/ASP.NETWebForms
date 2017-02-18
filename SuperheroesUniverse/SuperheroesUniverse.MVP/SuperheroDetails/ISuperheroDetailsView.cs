using System;
using WebFormsMvp;

namespace SuperheroesUniverse.MVP.SuperheroDetails
{
    public interface ISuperheroDetailsView:IView<SuperheroDetailsViewModel>
    {
        event EventHandler<SuperheroDetailsGetDataEventArgs> OnSuperheroDetailsGetData;
    }
}
