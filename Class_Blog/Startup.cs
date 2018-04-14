using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Class_Blog.Startup))]
namespace Class_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
