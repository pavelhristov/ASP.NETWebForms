using Ninject.Modules;
using SuperheroesUniverse.PresenterFactories;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Binder;
using Ninject.Extensions.Factory;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject;

namespace SuperheroesUniverse.NinjectBindingsModules
{
    public class MVPNinjectBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();
            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();
            this.Bind<IPresenter>().ToMethod(this.GetPresenterFactoryMethod)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenterFactoryMethod(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var requestedType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var viewInstanceConstructorParameter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(requestedType, viewInstanceConstructorParameter);
        }
    }
}