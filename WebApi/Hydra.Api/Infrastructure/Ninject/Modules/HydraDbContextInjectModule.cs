using Hydra.Persistence.MySql.Entity.Context;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Ninject.Web.Common;

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