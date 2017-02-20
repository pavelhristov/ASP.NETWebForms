using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace SuperheroesUniverse.MVP.EditSuperheroes
{
    public interface IEditSuperheroesView : IView<EditSuperheroesViewModel>
    {
        event EventHandler OnSuperheroesGetData;

        event EventHandler OnSuperheroInsert;

        event EventHandler<EditSuperheroesIdEventArgs> OnSuperheroDelete;

        event EventHandler<EditSuperheroesIdEventArgs> OnSuperheroUpdate;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
