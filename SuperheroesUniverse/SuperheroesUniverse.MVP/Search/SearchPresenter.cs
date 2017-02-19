using SuperheroesUniverse.Services;
using WebFormsMvp;

namespace SuperheroesUniverse.MVP.Search
{
    public class SearchPresenter : Presenter<ISearchView>
    {
        private readonly ISuperheroesService superheroesService;
        public SearchPresenter(ISearchView view, ISuperheroesService superheroesService) 
            : base(view)
        {
            this.superheroesService = superheroesService;

            this.View.OnSearchGetData += this.View_OnSearchGetData;
        }

        private void View_OnSearchGetData(object sender, SearchGetDataEventArgs e)
        {
            this.View.Model.Superheroes = this.superheroesService.Search(e.SearchPattern);
        }
    }
}
