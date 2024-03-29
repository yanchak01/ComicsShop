﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OtherLogic.IRepo
{
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task Insert(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        void SetStateModified(TEntity entity);
        Task<int> Save();
    }
}
