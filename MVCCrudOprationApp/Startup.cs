using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCrudOprationApp.Startup))]
namespace MVCCrudOprationApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
