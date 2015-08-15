using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Hydra.Api.Controllers
{
    public static class ResponseErrorUtil
    {

        public static HttpResponseMessage CreateResponseError(HttpRequestMessage request, ModelStateDictionary modelState)
        {
            Dictionary<string, IEnumerable<string>> errors = new Dictionary<string, IEnumerable<string>>();
            foreach (var keyvalue in modelState)
            {
                errors[keyvalue.Key] = keyvalue.Value.Errors.Select(s => s.ErrorMessage);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, errors);
        }

    }
}