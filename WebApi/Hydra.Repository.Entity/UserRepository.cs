using Hydra.Domain;
using Hydra.Persistence.MySql.Entity.Context;
using Mogo.Repository.Generic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Hydra.Repository.Entity
{
    public class UserRepository : MogoAbstractRepository<User, long>
    {
        public UserRepository(HydraDbContext context)
            : base(context)
        {

        }

        public override User FindById(long key, params string[] includeProperties)
        {
            if (includeProperties.Count() == 0)
            {
                return base.FindById(key, includeProperties);
            }
            else
            {
                IQueryable<User> users = _context.Set<User>().Where(p => p.Id == key);
                includeProperties.ToList().ForEach(property =>
                {
                    users = users.Include(property);
                });
                return users.FirstOrDefault();
            }
        }

    }
}
