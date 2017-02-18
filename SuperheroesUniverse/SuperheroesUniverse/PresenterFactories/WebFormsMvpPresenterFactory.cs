using Bytes2you.Validation;
using System;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace SuperheroesUniverse.PresenterFactories
{
    public class WebFormsMvpPresenterFactory : IPresenterFactory
    {
        private readonly ICustomPresenterFactory customPresenterFactory;

        public WebFormsMvpPresenterFactory(ICustomPresenterFactory customPresenterFactory)
        {
            Guard.WhenArgument(customPresenterFactory, nameof(customPresenterFactory)).IsNull().Throw();

            this.customPresenterFactory = customPresenterFactory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.customPresenterFactory.GetPresenter(presenterType, viewInstance);
        }

        public void Release(IPresenter presenter)
        {
            if (presenter is IDisposable)
            {
                (presenter as IDisposable).Dispose();
            }
        }
    }
}