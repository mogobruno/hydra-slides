using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mogo.Repository.Generic.Entity
{
    public class MogoAbstractRepository<TEntity, TKey>
        where TEntity : class
    {

        protected DbContext _context;

        public MogoAbstractRepository(DbContext context)
        {
            _context = context;
        }

        public virtual IList<TEntity> Select(Expression<Func<TEntity, bool>> where = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                int skip = 0, int take = 0, params string[] includeProperties)
        {
            IQueryable<TEntity> result;
            if (where == null)
            {
                result = _context.Set<TEntity>();
            }
            else
            {
                result = _context.Set<TEntity>().Where(where);
            }
            includeProperties.ToList().ForEach(property =>
            {
                result = result.Include(property);
            });
            if (orderBy != null)
            {
                result = orderBy(result);
            }
            if (skip > 0)
            {
                result = result.Skip(skip);
            }
            if (take > 0)
            {
                result = result.Take(take);
            }

            return result.ToList();
        }

        public virtual TEntity FindById(TKey key, params string[] includeProperties)
        {
            return _context.Set<TEntity>().Find(key);
        }

        public virtual int Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }

        public virtual int Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public virtual int Delete(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            return _context.SaveChanges();
        }
    }
}
