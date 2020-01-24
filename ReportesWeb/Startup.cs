using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReportesWeb.Startup))]
namespace ReportesWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
