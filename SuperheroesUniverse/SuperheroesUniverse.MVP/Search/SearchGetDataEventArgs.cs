using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.MVP.Search
{
    public class SearchGetDataEventArgs:EventArgs
    {
        public SearchGetDataEventArgs(string search)
        {
            this.SearchPattern = search;
        }

        public string SearchPattern { get; private set; }
    }
}
