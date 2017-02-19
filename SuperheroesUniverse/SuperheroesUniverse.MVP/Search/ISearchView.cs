using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SuperheroesUniverse.MVP.Search
{
    public interface ISearchView: IView<SearchViewModel>
    {
        event EventHandler<SearchGetDataEventArgs> OnSearchGetData;
    }
}
