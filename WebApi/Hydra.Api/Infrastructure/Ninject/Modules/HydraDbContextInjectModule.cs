using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Ninject.Web.Common;
using Hydra.Persistence.SqlServer.Entity.Context;

namespace Hydra.Api.Infrastructure.Ninject.Modules
{
    public class HydraDbContextInjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<HydraDbContext>()
                .ToSelf()
                .InRequestScope();
        }
    }
}