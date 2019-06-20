using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ManageInterfaces
{
    public interface IComicsAuthorManager<TEntity> where TEntity:class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid Id);
    }
}
