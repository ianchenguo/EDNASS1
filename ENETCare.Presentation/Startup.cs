using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ENETCare.Presentation.Startup))]
namespace ENETCare.Presentation
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
