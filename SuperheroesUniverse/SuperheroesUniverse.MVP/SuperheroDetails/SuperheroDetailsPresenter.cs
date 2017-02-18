using SuperheroesUniverse.Services;
using WebFormsMvp;

namespace SuperheroesUniverse.MVP.SuperheroDetails
{
    public class SuperheroDetailsPresenter : Presenter<ISuperheroDetailsView>
    {
        private readonly ISuperheroesService superheroesService;

        public SuperheroDetailsPresenter(ISuperheroDetailsView view, ISuperheroesService superheroesService) 
            : base(view)
        {
            this.superheroesService = superheroesService;

            this.View.OnSuperheroDetailsGetData += this.View_OnSuperheroDetailsGetData;
        }

        private void View_OnSuperheroDetailsGetData(object sender, SuperheroDetailsGetDataEventArgs e)
        {
            this.View.Model.Superhero = this.superheroesService.GetById(e.SuperheroId);
        }
    }
}
