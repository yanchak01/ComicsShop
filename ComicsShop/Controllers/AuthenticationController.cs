using AuthorizationsAboutToken;
using AuthorizationsAboutToken.Interfaces;
using DAL.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AuthenticationController(
            IAuthenticateService authenticateService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            this.authenticateService = authenticateService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [AllowAnonymous]
        [HttpPost("RequestToken")]
        public ActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token;
            if (authenticateService.IsAuthenticated(request, out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");

        }


        [AllowAnonymous]
        [HttpPost("GetToken")]
        // [ValidateAntiForgeryToken]
        public async Task GetToken([FromBody]TokenRequest request)
        {

            var identity = await authenticateService.GetIdentity(request.UserName, request.Password);

            var token = authenticateService.GenerateToken(identity);

            await Response.WriteAsync(JsonConvert.SerializeObject("Token : " + token,
                new JsonSerializerSettings { Formatting = Formatting.Indented }
            ));
        }

        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task Registration(RegistrationDTO model)
        {
            //ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var role = model.Role == null ? model.Role = RolesEnum.User.ToString() : model.Role;
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    

                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }

                
            }
             
        }

        
    }
}
