using AutoMapper;
using ComicsShop.BLL.Interfaces;
using DAL.DBModels;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;

namespace BLL.Managers
{
    public class ComicsAuthorManager<TEntity> : IComicsAuthorManager<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<ComicsAuthor> _baseRepository;
        private readonly IMapper _mapper;
        public ComicsAuthorManager(IBaseRepository<ComicsAuthor> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public void Delete(Guid Id)
        {
            ComicsAuthor entity = _baseRepository.GetById(Id);
            _baseRepository.Delete(entity);
            _baseRepository.Save();
        }

        public void Insert(TEntity entity)
        {
           var EMP = _mapper.Map<TEntity, ComicsAuthor>(entity);
            _baseRepository.Insert(EMP);
            _baseRepository.Save();
        }

        public void Update(TEntity entity)
        {
            var emp = _mapper.Map<TEntity, ComicsAuthor>(entity);
            _baseRepository.Update(emp);
            _baseRepository.Save();
        }

        public IEnumerable<ComicsAuthor> GetAll()
        {
            return _baseRepository.GetAll();
        }


    }
}
