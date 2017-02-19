using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.MVP.Superheroes;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SuperheroesUniverse
{
    [PresenterBinding(typeof(SuperheroesPresenter))]
    public partial class Superheroes : MvpPage<SuperheroesViewModel>, ISuperheroesView
    {
        public event EventHandler OnSuperheroesGetData;

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Superhero> ListViewSuperheroes_GetData()
        {
            this.OnSuperheroesGetData?.Invoke(this, null);

            return this.Model.Superheroes;
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string pattern = this.TextBoxSearch.Text;
            string queryParams = string.IsNullOrWhiteSpace(pattern) ? string.Empty : $"?search={pattern}";

            Response.Redirect("~/search"+queryParams);
        }
    }
}