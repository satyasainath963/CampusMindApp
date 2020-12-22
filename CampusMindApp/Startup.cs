using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampusMindApp.Startup))]
namespace CampusMindApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
