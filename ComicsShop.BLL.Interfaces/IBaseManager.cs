using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComicsShop.BLL.Interfaces
{
    public interface IBaseManager<TEntity> where TEntity:class
    {
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<IEnumerable<TEntity>>Get();
        Task<TEntity> Get(TEntity entity); 
    }
}
