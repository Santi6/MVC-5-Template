using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialNetworkSystem.Web.Startup))]
namespace SocialNetworkSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
