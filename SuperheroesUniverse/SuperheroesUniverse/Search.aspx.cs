using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.MVP.Search;
using System;
using System.Linq;
using System.Web.ModelBinding;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SuperheroesUniverse
{
    [PresenterBinding(typeof(SearchPresenter))]
    public partial class Search : MvpPage<SearchViewModel>, ISearchView
    {
        public event EventHandler<SearchGetDataEventArgs> OnSearchGetData;
        
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Superhero> ListViewFoundSuperheroes_GetData([QueryString] string q)
        {
            this.OnSearchGetData?.Invoke(this, new SearchGetDataEventArgs(q));

            return this.Model.Superheroes;           
        }
    }
}