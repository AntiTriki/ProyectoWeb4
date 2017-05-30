using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlantillaComercio.Startup))]
namespace PlantillaComercio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
