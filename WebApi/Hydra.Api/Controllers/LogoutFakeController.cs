using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hydra.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "POST")]
    public class LogoutFakeController : ApiController
    {
        

        // POST: api/LogoutFake
        public void Post([FromBody]string value)
        {
        }

       
    }
}
