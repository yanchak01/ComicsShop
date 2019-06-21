using BLL.ManageInterfaces;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.MainModelsDTO;
using System;
using System.Collections.Generic;

namespace ComicsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicAuthorController
    {
        private readonly IComicsAuthorManager<ComicsAuthorDTO> _comicsAuthorManager;
        public ComicAuthorController(IComicsAuthorManager<ComicsAuthorDTO> comicsAuthorManager)
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

        //[HttpGet]
        //public IEnumerable<ComicsDTO> GetAllComicsOfAuthor(ComicsAuthorDTO comicsAuthorDTO)
        //{
        //    var 
        //}
    }
}
