using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sisemp.Startup))]
namespace Sisemp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
