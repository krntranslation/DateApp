using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommonDate.Startup))]
namespace CommonDate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
