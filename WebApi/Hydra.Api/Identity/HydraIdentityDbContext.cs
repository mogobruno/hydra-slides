using AspNet.Identity.MySQL;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hydra.Api.Identity
{
    public class HydraIdentityDbContext : MySQLDatabase
    {
        public HydraIdentityDbContext(string connectionName)
            : base(connectionName)
        {

        }
    }
}