using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ComicsShop.DTO;
using System.Collections.Generic;
using System.Linq;
using ComicsShop.BLL.Interfaces;

namespace ComicsShop.Web.Controllers
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


        [HttpPost]
       [Authorize(Roles ="ComicsSeller")]
        public void CreateComics(ComicsDTO comicsDTO)
        {
            _comicsManager.Insert(comicsDTO);
            
        }

        [HttpDelete]
        [Authorize(Roles = "ComicsSeller")]
        public void DeleteComics(ComicsDTO comicsDTO)
        {
            var comics =_comicsManager.GetAll().Where(x => x.Name == comicsDTO.Name && x.Series == comicsDTO.Series).FirstOrDefault();
            _comicsManager.Delete(comics.Id);
        }

        [HttpPut]
        [Authorize(Roles = "ComicsSeller")]
        public void UpdateComics(ComicsDTO comicsDTO)
        {
            _comicsManager.Update(comicsDTO);
        }
        
        [HttpGet]
        public IEnumerable<ComicsDTO> GetAllComics()
        {
            return _comicsManager.GetAll();
        }


    }
}
