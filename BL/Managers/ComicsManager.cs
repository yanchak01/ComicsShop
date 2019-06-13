using AutoMapper;
using BLL.ManageInterfaces;
using BLL.Services;
using DAL.DBModels;
using Model.DTOs;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

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
            Comics com = baseRepository.GetById(id);
            baseRepository.Delete(com);
        }

        public IEnumerable<ComicsDTO> GetAll()
        {
           var comics = baseRepository.GetAll();
            return mapper.Map<IEnumerable<Comics>, IEnumerable<ComicsDTO>>(comics);
        }

        public ComicsDTO GetById(Guid id)
        {
            var com = baseRepository.GetById(id);
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
        }
    }
}
