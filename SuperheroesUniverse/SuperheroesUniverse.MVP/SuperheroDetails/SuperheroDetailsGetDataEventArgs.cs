using System;

namespace SuperheroesUniverse.MVP.SuperheroDetails
{
    public class SuperheroDetailsGetDataEventArgs: EventArgs
    {
        public SuperheroDetailsGetDataEventArgs(Guid? id)
        {
            this.SuperheroId = id;
        }

        public Guid? SuperheroId { get; private set; }
    }
}
