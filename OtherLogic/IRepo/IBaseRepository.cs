using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OtherLogic.IRepo
{
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        void Insert(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        void SetStateModified(TEntity entity);
        int Save();
    }
}
