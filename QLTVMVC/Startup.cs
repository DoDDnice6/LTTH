using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLTVMVC.Startup))]
namespace QLTVMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
