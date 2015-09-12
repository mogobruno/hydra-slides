using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hydra.Api.DTO
{
    public class UserLoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}