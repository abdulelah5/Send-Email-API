using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SendEmailAPI.Startup))]
namespace SendEmailAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
