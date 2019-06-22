using ComicsShop.DTO;
using System;
using System.Collections.Generic;

namespace ComicsShop.BLL.Interfaces
{
    public interface IComicsManager
    {
        void Insert(ComicsDTO comicsDTO);
        void Update(ComicsDTO comicsDTO);
        void Delete(Guid id);
        IEnumerable<ComicsDTO> GetAll();
        ComicsDTO GetById(Guid id);

    }
}
