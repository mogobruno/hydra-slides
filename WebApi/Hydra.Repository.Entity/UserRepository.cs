using Hydra.Domain;
using Hydra.Persistence.MySql.Entity.Context;
using Mogo.Repository.Generic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Repository.Entity
{
    public class UserRepository : MogoAbstractRepository<User, long>
    {
        public UserRepository(HydraDbContext context)
            : base(context)
        {

        }
    }
}
