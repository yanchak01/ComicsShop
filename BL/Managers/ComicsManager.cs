using AutoMapper;
using ComicsShop.DTO;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;
using ComicsShop.BLL.Interfaces;
using DAL.DBModels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BLL.Managers
{
    public class ComicsManager : IComicsManager
    {
        private readonly IBaseRepository<Comics> _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ComicsManager> _loger;
        public ComicsManager(IBaseRepository<Comics> baseRepository, IMapper mapper, ILogger<ComicsManager> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _loger = logger;
        }
        public async Task Delete(Guid id)
        {
            try
            {
                Comics com = await _baseRepository.Get(id);
                _baseRepository.Delete(com);
                await _baseRepository.Save();
            }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
            }
        }

        public async Task<IEnumerable<ComicsDTO>> GetAll()
        {
            try
            {
                var comics = await _baseRepository.Get();
                return _mapper.Map<IEnumerable<Comics>, IEnumerable<ComicsDTO>>(comics);
            }
            catch (Exception ex)
            {
                _loger.LogError(ex.Message);
                List<ComicsDTO> comicsDTOs = new List<ComicsDTO>();
                return comicsDTOs;
            }
        }

        public async Task<ComicsDTO> GetById(Guid id)
        {
            try
            {
                var com = await _baseRepository.Get(id);
                return _mapper.Map<Comics, ComicsDTO>(com);
            }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
                return new ComicsDTO();
            }
        }

        public async Task Insert(ComicsDTO comicsDTO)
        {
            try
            {
                Comics comics = _mapper.Map<ComicsDTO, Comics>(comicsDTO);
                comics.DateCreated = DateTime.Now;
                comics.DateModified = DateTime.Now;
                await _baseRepository.Insert(comics);
                await _baseRepository.Save();
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
                _baseRepository.Update(comics);
                await _baseRepository.Save();
            }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
            }
        }
    }
}
