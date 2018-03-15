using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Notify.Startup))]
namespace Notify
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
