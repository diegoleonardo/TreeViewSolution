using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TreeViewExamples.MVC.Startup))]
namespace TreeViewExamples.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
