using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamRoom_R33.Startup))]
namespace ExamRoom_R33
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
