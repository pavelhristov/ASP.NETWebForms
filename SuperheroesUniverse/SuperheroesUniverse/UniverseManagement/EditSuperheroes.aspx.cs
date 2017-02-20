using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.MVP.EditSuperheroes;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SuperheroesUniverse.UniverseManagement
{
    [PresenterBinding(typeof(EditSuperheroesPresenter))]
    public partial class EditSuperheroes : MvpPage<EditSuperheroesViewModel>, IEditSuperheroesView
    {
        public event EventHandler OnSuperheroesGetData;
        public event EventHandler OnSuperheroInsert;
        public event EventHandler<EditSuperheroesIdEventArgs> OnSuperheroDelete;
        public event EventHandler<EditSuperheroesIdEventArgs> OnSuperheroUpdate;
        public event EventHandler<EditSuperheroesIdEventArgs> OnSuperheroRestore;

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Superhero> ListViewEditSuperheroes_GetData()
        {
            this.OnSuperheroesGetData?.Invoke(this, null);

            return this.Model.Superheroes;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewEditSuperheroes_UpdateItem(Guid id)
        {
            this.OnSuperheroUpdate?.Invoke(this, new EditSuperheroesIdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewEditSuperheroes_DeleteItem(Guid? id)
        {
            // TODO: Implement Restore functionality!
            this.OnSuperheroDelete?.Invoke(this, new EditSuperheroesIdEventArgs(id));
        }

        public void ListViewEditSuperheroes_InsertItem()
        {
            this.OnSuperheroInsert?.Invoke(this, null);
            this.ListViewEditSuperheroes.InsertItemPosition = InsertItemPosition.None;
            this.ListViewEditSuperheroes.FindControl("LinkButtonInsert").Visible = true;
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.ListViewEditSuperheroes.InsertItemPosition = InsertItemPosition.LastItem;
            this.ListViewEditSuperheroes.FindControl("LinkButtonInsert").Visible = false;
        }

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            this.ListViewEditSuperheroes.InsertItemPosition = InsertItemPosition.None;
            this.ListViewEditSuperheroes.FindControl("LinkButtonInsert").Visible = true;
        }

        protected void LinkButtonRestore_Command(object sender, CommandEventArgs e)
        {
            Guid? id = Guid.Parse(e.CommandArgument.ToString());
            this.OnSuperheroRestore?.Invoke(this, new EditSuperheroesIdEventArgs(id));
        }
    }
}