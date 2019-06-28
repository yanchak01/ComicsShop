using Microsoft.EntityFrameworkCore;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Reposetories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity:class
    {
        protected readonly ComicsDbContext context;

        private DbSet<TEntity> dbSet;
        public BaseRepository(ComicsDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
            
        }

        public void Delete(TEntity item)
        {
            dbSet.Remove(item);
        }

        public virtual async  Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query =  query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Insert(TEntity item)
        {
            await dbSet.AddAsync(item);
        }

        public void SetStateModified(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Update(TEntity item)
        {
            try
            {
                dbSet.Attach(item);
            }
            catch
            {

            }
            finally
            {
                dbSet.Update(item);
            }
        }
        public async Task<int> Save()
        {
           return await context.SaveChangesAsync();
        }
    }
}
