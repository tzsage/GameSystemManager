using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemManager.Startup))]
namespace SystemManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
