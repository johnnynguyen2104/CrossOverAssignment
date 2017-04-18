using CrossOverAssignment.Security;
using CrossOverAssignment.Security.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossOverAssignment.Startup))]
namespace CrossOverAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            AuthConfig.ConfigureAuth(app);
        }
    }
}
