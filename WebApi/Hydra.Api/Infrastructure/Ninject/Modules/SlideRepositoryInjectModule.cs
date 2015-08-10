using Hydra.Domain;
using Hydra.Repository.Entity;
using Mogo.Repository.Generic.Entity;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydra.Api.Infrastructure.Ninject.Modules
{
    public class SlideRepositoryInjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MogoAbstractRepository<Slide, long>>()
                .To<SlideRepository>();
        }
    }
}