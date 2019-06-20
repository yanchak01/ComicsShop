using AutoMapper;
using BLL.ManageInterfaces;
using DAL.DBModels;
using OtherLogic.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Managers
{
    public class EmployeeManager<TEntity> : IEmployeeManager<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<Employee> _baseRepository;
        private readonly IMapper _mapper;
        public EmployeeManager(IBaseRepository<Employee> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public void Delete(Guid Id)
        {
            Employee entity = _baseRepository.GetById(Id);
            _baseRepository.Delete(entity);
            _baseRepository.Save();
        }

        public void Insert(TEntity entity)
        {
           var EMP = _mapper.Map<TEntity, Employee>(entity);
            _baseRepository.Insert(EMP);
            _baseRepository.Save();
        }

        public void Update(TEntity entity)
        {
            var emp = _mapper.Map<TEntity, Employee>(entity);
            _baseRepository.Update(emp);
            _baseRepository.Save();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _baseRepository.GetAll();
        }


    }
}
