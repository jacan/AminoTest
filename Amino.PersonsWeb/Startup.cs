using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Amino.PersonsWeb.Startup))]
namespace Amino.PersonsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
