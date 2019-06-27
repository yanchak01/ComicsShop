using ComicsShop.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComicsShop.BLL.Interfaces
{
    public interface IBaseManager<TEntity> where TEntity:EntityDTO
    {
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<IEnumerable<TEntity>>Get();
        Task<TEntity> Get(TEntity entity); 
    }
}
