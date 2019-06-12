using BLL.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Reposetories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity:class
    {
        protected readonly ComDbContext context;

        private DbSet<TEntity> dbSet;
        public BaseRepository(ComDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity item)
        {
            dbSet.Remove(item);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity item)
        {
            dbSet.Add(item);
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
    }
}
