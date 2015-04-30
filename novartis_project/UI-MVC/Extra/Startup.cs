using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JPP.UI.Web.MVC.Startup))]
namespace JPP.UI.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
