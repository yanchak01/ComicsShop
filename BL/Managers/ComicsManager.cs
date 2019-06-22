using AutoMapper;
using ComicsShop.DTO;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;
using ComicsShop.BLL.Interfaces;
using DAL.DBModels;

namespace BLL.Managers
{
    public class ComicsManager : IComicsManager
    {
        private readonly IBaseRepository<Comics> baseRepository;
        private readonly IMapper mapper;
        public ComicsManager(IBaseRepository<Comics> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public void Delete(Guid id)
        {
            Comics com = baseRepository.Get(id);
            baseRepository.Delete(com);
            baseRepository.Save();
        }

        public IEnumerable<ComicsDTO> GetAll()
        {
           var comics = baseRepository.Get();
            return mapper.Map<IEnumerable<Comics>, IEnumerable<ComicsDTO>>(comics);
        }

        public ComicsDTO GetById(Guid id)
        {
            var com = baseRepository.Get(id);
            return mapper.Map<Comics, ComicsDTO>(com);
        }

        public void Insert(ComicsDTO comicsDTO)
        {
            Comics comics = mapper.Map<ComicsDTO, Comics>(comicsDTO);
            comics.DateCreated = DateTime.Now;
            comics.DateModified = DateTime.Now;
            baseRepository.Insert(comics);
            baseRepository.Save();
        }

        public void Update(ComicsDTO comicsDTO)
        {
            Comics comics = mapper.Map<ComicsDTO, Comics>(comicsDTO);
            baseRepository.Insert(comics);
            baseRepository.Save();
        }
    }
}
