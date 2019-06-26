using AutoMapper;
using ComicsShop.BLL.Interfaces;
using ComicsShop.DTO;
using DAL.DBModels;
using Microsoft.Extensions.Logging;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class ComicsAuthorManager: IComicsAuthorManager
    {
        private readonly IBaseRepository<ComicsAuthor> _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ComicsAuthorManager> _loger;
        public ComicsAuthorManager(IBaseRepository<ComicsAuthor> baseRepository, IMapper mapper, ILogger<ComicsAuthorManager> loger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _loger = loger;
        }
        public async Task Delete(ComicsAuthorDTO comicsAuthorDTO)
        {
            try
            {
                var id = comicsAuthorDTO.Id;
                ComicsAuthor entity = await _baseRepository.Get(id);
                _baseRepository.Delete(entity);
                await _baseRepository.Save();
            }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
                await _baseRepository.Save();
            }
            
        }

        public async Task Insert(ComicsAuthorDTO entity)
        {
            try
            {
                var EMP = _mapper.Map<ComicsAuthorDTO, ComicsAuthor>(entity);
                EMP.DateCreated = DateTime.Now;
                EMP.DateModified = DateTime.Now;
                await _baseRepository.Insert(EMP);
                await _baseRepository.Save();
            }
            catch (Exception ex)
            {
                _loger.LogError(ex.Message);
                await _baseRepository.Save();
            }
            
        }

        public async Task Update(ComicsAuthorDTO entity)
        {
            try
            {
                var emp = _mapper.Map<ComicsAuthorDTO, ComicsAuthor>(entity);
                emp.DateModified = DateTime.Now;
                _baseRepository.Update(emp);
                await _baseRepository.Save();
            }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
                await _baseRepository.Save();
            }
            
        }

        public async Task <IEnumerable<ComicsAuthorDTO>> Get()
        {
            IEnumerable<ComicsAuthorDTO> comicsAuthorDTOs;
            try
            {
                var comicsAuthors = await _baseRepository.Get();
                comicsAuthorDTOs = _mapper.Map<IEnumerable<ComicsAuthor>, IEnumerable<ComicsAuthorDTO>>(comicsAuthors);
                return comicsAuthorDTOs;
            }
            catch(Exception ex)
            {
                List<ComicsAuthorDTO> comicsAuthorDTOs1 = new List<ComicsAuthorDTO>();
                _loger.LogError(ex.Message);
                return comicsAuthorDTOs1;
            }
        }

        public async Task<ComicsAuthorDTO> Get(ComicsAuthorDTO entity)
        {
            try
            {
                var Id = entity.Id;
                var comicsAuthor = await _baseRepository.Get(x => x.Id == Id);
                var yy = comicsAuthor.First();
                return _mapper.Map<ComicsAuthor, ComicsAuthorDTO>(yy);
            }
            catch(Exception ex)
            {
                ComicsAuthorDTO comicsAuthorDTO = new ComicsAuthorDTO();
                _loger.LogError(ex.Message);
                return comicsAuthorDTO;
            }
        }
    }
}
