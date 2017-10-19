using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShortbrainWeb.Startup))]
namespace ShortbrainWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
