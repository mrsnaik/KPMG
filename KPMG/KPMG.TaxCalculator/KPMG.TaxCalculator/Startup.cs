using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KPMG.TaxCalculator.Startup))]
namespace KPMG.TaxCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
