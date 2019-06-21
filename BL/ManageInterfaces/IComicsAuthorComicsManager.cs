using Model.DTOs;
using System;

namespace BLL.ManageInterfaces
{
    public interface IComicsAuthorComicsManager
    {
        void Insert(ComicsAuthorComicsDTO comicsAuthorComicsDTO);
        void Update(ComicsAuthorComicsDTO comicsAuthorComicsDTO );
        void Delete(Guid comicsId, Guid comicsAuthorId);
    }
}
