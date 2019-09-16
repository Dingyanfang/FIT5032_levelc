using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fit5032_assignment_v4.Startup))]
namespace fit5032_assignment_v4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
