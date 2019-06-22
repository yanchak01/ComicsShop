using ComicsShop.DTO;
using DAL.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComicsShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SignInController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task Registration(RegistrationDTO model)
        {

            if (ModelState.IsValid)
            {
                var role = model.Role == null ? model.Role = RolesEnum.User.ToString() : model.Role;
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.Phone,


                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role);
                }


            }

        }
    }
}
