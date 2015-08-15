using Hydra.Api.App_Start;
using System.Web.Http;
using System.Web.Mvc;

namespace Hydra.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutoMapperConfig.InitializeMapper();
        }

    }
}
