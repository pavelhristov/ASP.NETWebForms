using System;

namespace SuperheroesUniverse.MVP.EditSuperheroes
{
    public class EditSuperheroesIdEventArgs : EventArgs
    {
        public EditSuperheroesIdEventArgs(Guid? id)
        {
            this.SuperheroId = id;
        }

        public Guid? SuperheroId { get; private set; }
    }
}
