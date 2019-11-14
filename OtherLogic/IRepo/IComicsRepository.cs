using OtherLogic.IRepo;

namespace ComicsShop.DAL.Interfaces.IRepo
{
    public  interface IComicsRepository<TEntity> : IBaseRepository<TEntity> where TEntity:class
    {
    }
}
