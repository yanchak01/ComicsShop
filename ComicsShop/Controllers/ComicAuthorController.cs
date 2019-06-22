﻿using Microsoft.AspNetCore.Mvc;
using System;
using ComicsShop.BLL.Interfaces;
using ComicsShop.DTO;

namespace ComicsShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicAuthorController:ControllerBase
    {
        private readonly IComicsAuthorManager _comicsAuthorManager;
        public ComicAuthorController(IComicsAuthorManager comicsAuthorManager)
        {
            _comicsAuthorManager = comicsAuthorManager;
        }
        [HttpPost]
        public ActionResult<ComicsAuthorDTO> CreateComicsAuthor(ComicsAuthorDTO comicsAuthorDTO)
        {

            _comicsAuthorManager.Insert(comicsAuthorDTO);
            return Ok(comicsAuthorDTO);

        }
        [HttpPut]
        public ActionResult<ComicsAuthorDTO> UpdateComicsAuthor(ComicsAuthorDTO comicsAuthorDTO)
        {
             _comicsAuthorManager.Update(comicsAuthorDTO);
            return Ok(comicsAuthorDTO);
        }
        [HttpDelete]
        public ActionResult DeleteComicsAuthor(ComicsAuthorDTO comicsAuthorDTO)
        {
            _comicsAuthorManager.Delete(comicsAuthorDTO);
            return Ok();
        }

       
    }
}
