using System;

namespace ComicsShop.BLL.Interfaces
{
    public interface IComicsAuthorManager<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid Id);
    }
 
}
