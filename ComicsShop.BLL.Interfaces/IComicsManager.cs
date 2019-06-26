using ComicsShop.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComicsShop.BLL.Interfaces
{
    public interface IComicsManager
    {
        Task Insert(ComicsDTO comicsDTO);
        Task Update(ComicsDTO comicsDTO);
        Task Delete(Guid id);
        Task <IEnumerable<ComicsDTO>> GetAll();
        Task <ComicsDTO> GetById(Guid id);

    }
}
