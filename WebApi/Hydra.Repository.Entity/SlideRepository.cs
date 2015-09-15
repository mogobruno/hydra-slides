using Hydra.Domain;
using Hydra.Persistence.SqlServer.Entity.Context;
using Mogo.Repository.Generic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Repository.Entity
{
    public class SlideRepository : MogoAbstractRepository<Slide, long>
    {
        public SlideRepository(HydraDbContext context)
            : base(context)
        {

        }
    }
}
