using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hydra.Api.Identity
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class HydraIdentityDbContext : IdentityDbContext<HydraIdentityUser>
    {
    }
}