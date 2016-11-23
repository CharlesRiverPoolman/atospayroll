using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtosPayroll.Startup))]
namespace AtosPayroll
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
