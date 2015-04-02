using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(a2.Startup))]
namespace a2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
