using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UMoveNew.Startup))]
namespace UMoveNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
