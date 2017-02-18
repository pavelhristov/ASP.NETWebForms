using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperheroesUniverse.Startup))]
namespace SuperheroesUniverse
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
