using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HIMS.Web.Startup))]
namespace HIMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
