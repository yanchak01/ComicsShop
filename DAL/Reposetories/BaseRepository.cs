﻿using Microsoft.EntityFrameworkCore;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public TEntity Get(Guid id)
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
        public int Save()
        {
           return context.SaveChanges();
        }
    }
}
