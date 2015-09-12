using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hydra.Api.Identity;
using Microsoft.Owin.Security.OAuth;
using AspNet.Identity.MySQL;

[assembly: OwinStartup(typeof(Hydra.Api.Startup))]

namespace Hydra.Api
{
    public class Startup
    {

        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new HydraIdentityDbContext("HydraIdentityDbContext") as MySQLDatabase);
            app.CreatePerOwinContext(() => new HydraUserManager(new UserStore<HydraIdentityUser>(new HydraIdentityDbContext("HydraIdentityDbContext") as MySQLDatabase)));
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
