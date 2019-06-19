using AutoMapper;
using BLL.ManageInterfaces;
using DAL.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController:ControllerBase
    {
        private readonly IComicsManager comicsManager;
        private readonly IMapper mapper;
        
        public ComicsController(IComicsManager comicsManager, IMapper mapper)
        {
            this.comicsManager = comicsManager;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        public void CreateComics(ComicsDTO comicsDTO)
        {

            comicsManager.Insert(comicsDTO);

        }

        public void DeleteComics(ComicsDTO comicsDTO)
        {
            var comics =comicsManager.GetAll().Where(x => x.Name == comicsDTO.Name).FirstOrDefault();
            comicsManager.Delete(comics.Id);
        }

        public void Update(ComicsDTO comicsDTO)
        {
            comicsManager.Update(comicsDTO);
        }
        
    }
}
