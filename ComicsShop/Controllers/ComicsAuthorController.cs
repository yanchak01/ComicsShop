using Microsoft.AspNetCore.Mvc;
using System;
using ComicsShop.BLL.Interfaces;
using ComicsShop.DTO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicsShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsAuthorController:ControllerBase
    {
        private readonly IComicsAuthorManager _comicsAuthorManager;
        public ComicsAuthorController(IComicsAuthorManager comicsAuthorManager)
        {
            _comicsAuthorManager = comicsAuthorManager;
        }
        [HttpPost]
        public async Task<ActionResult> CreateComicsAuthor(ComicsAuthorDTO comicsAuthorDTO)
        {

             await _comicsAuthorManager.Insert(comicsAuthorDTO);
            return Ok(comicsAuthorDTO);

        }
        [HttpPut]
        public async Task<ActionResult> UpdateComicsAuthor(ComicsAuthorDTO comicsAuthorDTO)
        {
             await _comicsAuthorManager.Update(comicsAuthorDTO);
            return Ok(comicsAuthorDTO);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteComicsAuthor(ComicsAuthorDTO comicsAuthorDTO)
        {
           await _comicsAuthorManager.Delete(comicsAuthorDTO);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var b = await _comicsAuthorManager.Get();
            return Ok(b);
        }
       
    }
}
