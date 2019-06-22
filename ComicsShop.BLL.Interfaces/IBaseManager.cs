using System;
using System.Collections.Generic;
using System.Text;

namespace ComicsShop.BLL.Interfaces
{
    public interface IBaseManager<TEntity> where TEntity:class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IEnumerable<TEntity>Get();
        TEntity Get(TEntity entity); 
    }
}
