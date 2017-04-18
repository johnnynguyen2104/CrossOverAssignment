using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossOverAssignment.Startup))]
namespace CrossOverAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
