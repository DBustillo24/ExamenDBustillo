using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenDBustillo.Startup))]
namespace ExamenDBustillo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
