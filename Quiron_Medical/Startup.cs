using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quiron_Medical.Startup))]
namespace Quiron_Medical
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
