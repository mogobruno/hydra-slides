using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hydra.Api.Identity
{
    public class HydraIdentityDbContext : IdentityDbContext<HydraIdentityUser>
    {
        public HydraIdentityDbContext(string connectionName)
            : base(connectionName)
        {

        }
    }
}