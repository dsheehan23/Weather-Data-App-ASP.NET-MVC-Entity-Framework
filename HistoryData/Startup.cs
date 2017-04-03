using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HistoryData.Startup))]
namespace HistoryData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
