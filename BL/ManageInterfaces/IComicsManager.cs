using System;
using System.Collections.Generic;
using System.Text;
using DAL.DBModels;
using Model.DTOs;

namespace BLL.ManageInterfaces
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
