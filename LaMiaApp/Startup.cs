using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaMiaApp.Startup))]
namespace LaMiaApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
