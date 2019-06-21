using AutoMapper;
using BLL.ManageInterfaces;
using DAL.DBModels;
using Microsoft.AspNetCore.Authorization;
using Model.DTOs;
using OtherLogic.IRepo;
using System;
using System.Linq;

namespace BLL.Managers
{
    [Authorize(Roles ="ComicsSeller")]
    public class ComicsAuthorComicsManager : IComicsAuthorComicsManager
    {
        private IBaseRepository<ComicsAuthorComics> _baseRepository;
        private IMapper _mapper;
        public ComicsAuthorComicsManager(IBaseRepository<ComicsAuthorComics> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public void Delete(Guid comicsId, Guid comicsAuthorId)
        {
            var cm = _baseRepository.Get(x => x.ComicsId == comicsId && x.ComicsAuthorId == comicsAuthorId).FirstOrDefault();
            _baseRepository.Delete(cm);
        }

        public void Insert(ComicsAuthorComicsDTO comicsAuthorComicsDTO)
        {
            var cac = _mapper.Map<ComicsAuthorComicsDTO, ComicsAuthorComics>(comicsAuthorComicsDTO);
            _baseRepository.Insert(cac);
        }

        public void Update(ComicsAuthorComicsDTO comicsAuthorComicsDTO)
        {
            var cac = _mapper.Map<ComicsAuthorComicsDTO, ComicsAuthorComics>(comicsAuthorComicsDTO);
            _baseRepository.Update(cac);
        }
    }
}
