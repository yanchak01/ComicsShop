using BLL.ManageInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;

namespace ComicsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController
    {
        private readonly IComicsAuthorManager<ArtistDTO> _employeeManager;

        public ArtistController(IComicsAuthorManager<ArtistDTO> employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpPost]
        [Authorize(Roles = "ComicsSeller")]
        public void CreateArtist(ArtistDTO artistDTO)
        {
            _employeeManager.Insert(artistDTO);
        }

        [HttpPut]
        [Authorize]
        public void UpdateArtist(ArtistDTO artistDTO)
        {

            _employeeManager.Update(artistDTO);

        }
    }
}
