using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(_365Plus.Web.Startup))]
namespace _365Plus.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
