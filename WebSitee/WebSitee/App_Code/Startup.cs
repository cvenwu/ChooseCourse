using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSitee.Startup))]
namespace WebSitee
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
