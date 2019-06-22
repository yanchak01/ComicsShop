using AutoMapper;
using ComicsShop.BLL.Interfaces;
using ComicsShop.DTO;
using DAL.DBModels;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;

namespace BLL.Managers
{
    public class ComicsAuthorManager: IComicsAuthorManager
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
            ComicsAuthor entity = _baseRepository.Get(Id);
            _baseRepository.Delete(entity);
            _baseRepository.Save();
        }

        public void Insert(ComicsAuthorDTO entity)
        {
           var EMP = _mapper.Map<ComicsAuthorDTO, ComicsAuthor>(entity);
            _baseRepository.Insert(EMP);
            _baseRepository.Save();
        }

        public void Update(ComicsAuthorDTO entity)
        {
            var emp = _mapper.Map<ComicsAuthorDTO, ComicsAuthor>(entity);
            _baseRepository.Update(emp);
            _baseRepository.Save();
        }

        public IEnumerable<ComicsAuthor> GetAll()
        {
            return _baseRepository.Get();
        }


    }
}
