using Bytes2you.Validation;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Services;
using System;
using WebFormsMvp;

namespace SuperheroesUniverse.MVP.EditSuperheroes
{
    public class EditSuperheroesPresenter : Presenter<IEditSuperheroesView>
    {
        private readonly ISuperheroesService superheroesService;

        public EditSuperheroesPresenter(
            IEditSuperheroesView view,
            ISuperheroesService superheroesService)
            : base(view)
        {
            Guard.WhenArgument(superheroesService, nameof(superheroesService)).IsNull().Throw();

            this.superheroesService = superheroesService;

            this.View.OnSuperheroesGetData += this.View_OnSuperheroesGetData;
            this.View.OnSuperheroInsert += this.View_OnSuperheroInsert;
            this.View.OnSuperheroDelete += this.View_OnSuperheroDelete;
            this.View.OnSuperheroUpdate += this.View_OnSuperheroUpdate;
            this.View.OnSuperheroRestore += this.View_OnSuperheroRestore;
        }

        private void View_OnSuperheroRestore(object sender, EditSuperheroesIdEventArgs e)
        {
            this.superheroesService.RestoreSuperhero(e.SuperheroId);
        }

        private void View_OnSuperheroUpdate(object sender, EditSuperheroesIdEventArgs e)
        {
            Superhero superhero = this.superheroesService.GetById(e.SuperheroId);
            if (superhero == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.SuperheroId));
                return;
            }

            this.View.TryUpdateModel(superhero);
            if (this.View.ModelState.IsValid)
            {
                this.superheroesService.UpdateSuperhero(superhero);
            }
        }

        private void View_OnSuperheroDelete(object sender, EditSuperheroesIdEventArgs e)
        {
            this.superheroesService.DeleteSuperhero(e.SuperheroId);
        }

        private void View_OnSuperheroInsert(object sender, EventArgs e)
        {
            Superhero superhero = new Superhero();
            this.View.TryUpdateModel(superhero);
            if (this.View.ModelState.IsValid)
            {
                this.superheroesService.InsertSuperhero(superhero);
            }
        }

        private void View_OnSuperheroesGetData(object sender, EventArgs e)
        {
            this.View.Model.Superheroes = this.superheroesService.ManagementGetAll();
        }
    }
}
