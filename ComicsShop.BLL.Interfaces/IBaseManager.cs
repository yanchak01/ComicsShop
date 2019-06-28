using ComicsShop.DAL.DBModels;
using ComicsShop.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComicsShop.BLL.Interfaces
{
    public interface IBaseManager<TEntityDTO,TEntityDBO> where TEntityDTO:EntityDTO where TEntityDBO:Entity
    {
        Task Insert(TEntityDTO entity);
        Task Update(TEntityDTO entity);
        Task Delete(TEntityDTO entity);
        Task<IEnumerable<TEntityDTO>>Get();
        Task<TEntityDTO> Get(Guid Id);
      

    }
}
