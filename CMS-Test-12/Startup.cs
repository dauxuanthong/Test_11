using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMS_Test_12.Startup))]
namespace CMS_Test_12
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
