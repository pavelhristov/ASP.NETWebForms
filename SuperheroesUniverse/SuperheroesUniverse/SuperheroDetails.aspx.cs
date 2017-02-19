using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.MVP.SuperheroDetails;
using System;
using System.Web.ModelBinding;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SuperheroesUniverse
{
    [PresenterBinding(typeof(SuperheroDetailsPresenter))]
    public partial class SuperheroDetails : MvpPage<SuperheroDetailsViewModel>, ISuperheroDetailsView
    {
        public event EventHandler<SuperheroDetailsGetDataEventArgs> OnSuperheroDetailsGetData;

        public Superhero FormViewSuperheroDetails_GetItem([QueryString] Guid? id)
        {
            this.OnSuperheroDetailsGetData?.Invoke(this, new SuperheroDetailsGetDataEventArgs(id));

            this.Title = string.IsNullOrWhiteSpace(id.ToString()) ? string.Empty : $"{this.Model.Superhero.Name}: Superhero Details";
            return this.Model.Superhero;
        }
    }
}