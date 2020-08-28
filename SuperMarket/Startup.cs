using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperMarket.Startup))]
namespace SuperMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
