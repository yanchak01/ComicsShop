using AutoMapper;
using ComicsShop.BLL.Interfaces;
using ComicsShop.DTO;
using DAL.DBModels;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void Delete(ComicsAuthorDTO comicsAuthorDTO)
        {
            var id = comicsAuthorDTO.Id;
            ComicsAuthor entity = _baseRepository.Get(id);
            _baseRepository.Delete(entity);
            _baseRepository.Save();
        }

        public void Insert(ComicsAuthorDTO entity)
        {
           var EMP = _mapper.Map<ComicsAuthorDTO, ComicsAuthor>(entity);
            EMP.DateCreated = DateTime.Now;
            EMP.DateModified = DateTime.Now;
            _baseRepository.Insert(EMP);
            _baseRepository.Save();
        }

        public void Update(ComicsAuthorDTO entity)
        {
            var emp = _mapper.Map<ComicsAuthorDTO, ComicsAuthor>(entity);
            emp.DateModified = DateTime.Now;
            _baseRepository.Update(emp);
            _baseRepository.Save();
        }

        public IEnumerable<ComicsAuthorDTO> Get()
        {
            var comicsAuthors = _baseRepository.Get();
            return _mapper.Map<IEnumerable<ComicsAuthor>, IEnumerable<ComicsAuthorDTO>>(comicsAuthors);
        }

        public ComicsAuthorDTO Get(ComicsAuthorDTO entity)
        {
            var Id = entity.Id;
            var comicsAuthor = _baseRepository.Get(x => x.Id == Id).FirstOrDefault();
            return _mapper.Map<ComicsAuthor, ComicsAuthorDTO>(comicsAuthor);
        }
    }
}
