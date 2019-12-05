using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRManagerWeb.Startup))]
namespace HRManagerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
