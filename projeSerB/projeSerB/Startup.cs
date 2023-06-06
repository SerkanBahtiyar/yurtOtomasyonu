using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projeSerB.Startup))]
namespace projeSerB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
