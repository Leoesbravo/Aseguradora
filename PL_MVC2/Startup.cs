using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PL_MVC2.Startup))]
namespace PL_MVC2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
