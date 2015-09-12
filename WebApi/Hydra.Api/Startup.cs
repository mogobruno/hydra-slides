using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hydra.Api.Identity;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(Hydra.Api.Startup))]

namespace Hydra.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new HydraIdentityDbContext());
            app.CreatePerOwinContext(() => new HydraUserManager(new UserStore<HydraIdentityUser>(new HydraIdentityDbContext())));
            OAuthAuthorizationServerOptions opt = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                AuthorizeEndpointPath = new PathString("/hydra/api/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true //TODO retirar quando for para produção
            };

            app.UseOAuthBearerTokens(opt);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
