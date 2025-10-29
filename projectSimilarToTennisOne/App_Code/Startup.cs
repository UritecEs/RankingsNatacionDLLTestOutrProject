using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projectSimilarToTennisOne.Startup))]
namespace projectSimilarToTennisOne
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
