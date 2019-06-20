using BLL.ManageInterfaces;
using DAL.DBModels;
using Microsoft.AspNetCore.Mvc;

namespace ComicsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicAuthorController
    {
        private readonly IComicsAuthorManager<ComicsAuthor> comicsAuthorManager;
        public ComicAuthorController()
        {

        }

    }
}
