using AutoMapper;
using ComicsShop.DTO;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;
using ComicsShop.BLL.Interfaces;
using DAL.DBModels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ComicsShop.DAL.Interfaces.IRepo;

namespace BLL.Managers
{
    public class ComicsManager : IComicsManager
    {
        private readonly IComicsRepository<Comics> _comicsRepository;
        
        private readonly IBaseRepository<ComicsAuthorComics> _compoundRRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ComicsManager> _loger;
        public ComicsManager(IComicsRepository<Comics> comicsRepository, 
            IMapper mapper, 
            ILogger<ComicsManager> logger
            )
        {
            _comicsRepository = comicsRepository;
            _mapper = mapper;
            _loger = logger;
        }
        public async Task Delete(ComicsDTO comicsDTO)
        {
            try
            {
                Comics com = await _comicsRepository.Get(comicsDTO.Id);
                _comicsRepository.Delete(com);
                await _comicsRepository.Save();
            }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
            }
        }

        public async Task<IEnumerable<ComicsDTO>> Get()
        {
            try
            {
                var comics = await _comicsRepository.Get();
                
                return _mapper.Map<IEnumerable<Comics>, IEnumerable<ComicsDTO>>(comics);
            }
            catch (Exception ex)
            {
                _loger.LogError(ex.Message);
                List<ComicsDTO> comicsDTOs = new List<ComicsDTO>();
                return comicsDTOs;
            }
        }

        public async Task<ComicsDTO> Get(Guid id)
        {
            try
            {
                var com = await _comicsRepository.Get(id);
                return _mapper.Map<Comics, ComicsDTO>(com);
            }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
                return new ComicsDTO();
            }
        }

        public async Task GettAllcomisFromAuthors(params ComicsAuthorDTO[] comicsAuthors)
        {
            try
            {
                var b = comicsAuthors;

                var com = await _comicsRepository.Get();
            }
            catch (Exception ex)
            {

                _loger.LogError(ex.Message);
            }
        }
        public async Task Insert(ComicsDTO comicsDTO)
        {
            try
            {
                Comics comics = _mapper.Map<ComicsDTO, Comics>(comicsDTO);
                comics.DateCreated = DateTime.Now;
                comics.DateModified = DateTime.Now;
                await _comicsRepository.Insert(comics);
                await _comicsRepository.Save();
        }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
            }
}

        public async Task Update(ComicsDTO comicsDTO)
        {
            try
            {
                Comics comics = _mapper.Map<ComicsDTO, Comics>(comicsDTO);
                _comicsRepository.Update(comics);
                await _comicsRepository.Save();
            }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
            }
        }
    }
}
