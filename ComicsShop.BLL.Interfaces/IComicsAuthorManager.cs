using ComicsShop.DTO;
using System;

namespace ComicsShop.BLL.Interfaces
{
    public interface IComicsAuthorManager
    {
        void Insert(ComicsAuthorDTO entity);
        void Update(ComicsAuthorDTO entity);
        void Delete(Guid Id);
    }
 
}
