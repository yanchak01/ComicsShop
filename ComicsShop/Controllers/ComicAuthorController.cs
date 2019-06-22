using Microsoft.AspNetCore.Mvc;
using System;
using ComicsShop.BLL.Interfaces;
using ComicsShop.DTO;

namespace ComicsShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicAuthorController
    {
        private readonly IComicsAuthorManager _comicsAuthorManager;
        public ComicAuthorController(IComicsAuthorManager comicsAuthorManager)
        {
            _comicsAuthorManager = comicsAuthorManager;
        }
        [HttpPost]
        public void CreateComicsAuthor(ComicsAuthorDTO comicsAuthorDTO)
        {

            _comicsAuthorManager.Insert(comicsAuthorDTO);

        }
        [HttpPut]
        public void UpdateComicsAuthor(ComicsAuthorDTO comicsAuthorDTO)
        {
            _comicsAuthorManager.Update(comicsAuthorDTO);
        }
        [HttpDelete]
        public void DeleteComicsAuthor(Guid Id)
        {
            _comicsAuthorManager.Delete(Id);
        }

        
    }
}
