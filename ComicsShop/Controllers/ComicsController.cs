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
        private readonly IComicsManager _comicsManager;
        private readonly IMapper _mapper;
      
        
        public ComicsController(IComicsManager comicsManager, IMapper mapper)
        {
            _comicsManager = comicsManager;
            _mapper = mapper;
           
        }


        [HttpPost("cc")]
       // [Authorize(Roles ="ComicsSeller")]
        public void CreateComics(ArtistDTO comicsDTO)
        {
            
            
        }

        [HttpDelete]
        [Authorize(Roles = "ComicsSeller")]
        public void DeleteComics(ComicsDTO comicsDTO)
        {
            var comics =_comicsManager.GetAll().Where(x => x.Name == comicsDTO.Name).FirstOrDefault();
            _comicsManager.Delete(comics.Id);
        }

        [HttpPut]
        [Authorize(Roles = "ComicsSeller")]
        public void UpdateComics(ComicsDTO comicsDTO)
        {
            _comicsManager.Update(comicsDTO);
        }
        
    }
}
