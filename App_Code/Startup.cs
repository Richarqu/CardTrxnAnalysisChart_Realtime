using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CardTrxnAnalysisChart.Startup))]
namespace CardTrxnAnalysisChart
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
