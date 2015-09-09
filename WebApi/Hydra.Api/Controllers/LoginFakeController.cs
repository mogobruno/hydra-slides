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
    public class LoginFakeController : ApiController
    {

        private Dictionary<string, string> response = new Dictionary<string, string>();

        public LoginFakeController()
        {
            response["name"] = "Bruno Silva";
            response["token"] = "sad2sj1h2skj14h3jh4kj3hksj23h4kj3s2h4kj3hk4jahkj4hkc41lk3j2lk3j1k23jx12k3";
        }

        // POST: api/LoginFake
        public Dictionary<string,string> Post([FromBody]string value)
        {
            return response;
        }

    }
}


