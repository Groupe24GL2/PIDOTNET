using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PIDOTNET.WEB.Startup))]
namespace PIDOTNET.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
