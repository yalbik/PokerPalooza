using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pokerpalooza.Startup))]
namespace pokerpalooza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
