using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ComicsShop.DTO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using AuthorizationsAboutToken.Interfaces;
using DAL.DBModels;
using System.Collections.Generic;

namespace ComicsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentificationService authenticateService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AuthenticationController(
            IAuthentificationService authenticateService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            this.authenticateService = authenticateService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public async Task<ActionResult> GetToken(LoginDTO request)
        {

            var identity = await authenticateService.GetIdentity(request.UserName, request.Password);

            var token = authenticateService.GenerateToken(identity);

             await Response.WriteAsync(JsonConvert.SerializeObject(token,
                new JsonSerializerSettings { Formatting = Formatting.Indented }
            ));
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task<ActionResult> Registration(RegistrationDTO model)
        {

             await authenticateService.Registration(model, ModelState.IsValid);


            return Ok();
        }
      
    }
}
