using System;
using WebFormsMvp;

namespace SuperheroesUniverse.PresenterFactories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
