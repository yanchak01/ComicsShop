using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ComicsShop.DTO;
using System.Collections.Generic;
using System.Linq;
using ComicsShop.BLL.Interfaces;
using Serilog;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ComicsShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController:ControllerBase
    {
        private readonly IComicsManager _comicsManager;
        private readonly IMapper _mapper;
        private readonly ILogger<ComicsController> _loger;
        
        public ComicsController(IComicsManager comicsManager, IMapper mapper,ILogger<ComicsController>logger)
        {
            _comicsManager = comicsManager;
            _mapper = mapper;
            _loger = logger;
        }


        [HttpPost]
       //[Authorize(Roles ="ComicsSeller")]
        public async Task<ActionResult> CreateComics(ComicsDTO comicsDTO)
        {
                await _comicsManager.Insert(comicsDTO);
            return Ok();  
        }

        [HttpDelete]
        [Authorize(Roles = "ComicsSeller")]
        public async Task<ActionResult> DeleteComics(ComicsDTO comicsDTO)
        {
            var cs = await _comicsManager.Get();
            var comics = cs.Where(x => x.Id == comicsDTO.Id).FirstOrDefault();
            await _comicsManager.Delete(comics);
            return Ok();
        }

        [HttpPut]
        //[Authorize(Roles = "ComicsSeller")]
        public async Task<ActionResult> UpdateComics(ComicsDTO comicsDTO)
        {
            await _comicsManager.Update(comicsDTO);
            return Ok();
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllComics()
        {
            return Ok(await _comicsManager.Get());
        }

        //[HttpGet]
        //public async Task ReturnComicsFromAuthor(params ComicsAuthorDTO[] comicsAuthors)
        //{
            
        //}

    }
}
