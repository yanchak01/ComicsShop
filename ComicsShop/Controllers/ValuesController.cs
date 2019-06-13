using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.ManageInterfaces;
using DAL.DBModels;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;

namespace ComicsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IComicsManager comicsManager;

        public ValuesController(IComicsManager comicsManager)
        {
            this.comicsManager = comicsManager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ComicsDTO>> Get()
        {
            ComicsDTO[]comicsDTO = comicsManager.GetAll().ToArray();
            return comicsDTO;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ComicsDTO value)
        {
            comicsManager.Insert(value);
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            comicsManager.Delete(id);
        }
    }
}
