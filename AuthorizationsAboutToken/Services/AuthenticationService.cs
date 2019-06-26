using AuthorizationsAboutToken.Interfaces;
using AuthorizationsAboutToken.Models;
using AutoMapper;
using DAL.DBModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ComicsShop.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
//using Serilog;

namespace AuthorizationsAboutToken.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IUserManagementService _userManagementService;
        private readonly TokenManagemant _tokenManagement;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _loger;

        public AuthentificationService(IUserManagementService userManagementService, 
            IOptions<TokenManagemant> tokenManagement, 
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger loger)
        {
            _userManagementService = userManagementService;
            _tokenManagement = tokenManagement.Value;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _loger = loger;
        }

        public string GenerateToken(ClaimsIdentity identity)
        {
            try
            {
                var now = DateTime.UtcNow;
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityToken(
                    _tokenManagement.Issuer,
                    _tokenManagement.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                    signingCredentials: credentials
                );
                var tokenjwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                return $"Bearer {tokenjwt}";
            }
            catch (Exception ex)
            {
                _loger.LogError(ex.Message);
                return "Exception, token was not generated";
            }
            finally
            {
                
            }
        }

        public async Task<ClaimsIdentity> GetIdentity(string userName, string password)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user == null)
                {
                    throw new Exception("The user not found");
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, password, false, false);
                if (result.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);


                    if (!userRoles.Any() || userRoles.Count > 1)
                    {
                        throw new Exception("Incorect user roles( 0 or more then 1)");
                    }

                    var userRole = userRoles.Single();

                    var claims = new List<Claim>
             {
                 new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                 new Claim(ClaimsIdentity.DefaultRoleClaimType,userRole),
                 new Claim("UserId", user.Id),
                 new Claim("Email", user.Email)
             };

                    var claimIdentity =
                        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    return claimIdentity;
                }
                return new ClaimsIdentity();
            }
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
                return null;
            }
            finally
            {

            }
        }

        public async Task Registration(RegistrationDTO model,bool ModelValid)
        {
            try
            {
                if (ModelValid == true)
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
            catch(Exception ex)
            {
                _loger.LogError(ex.Message);
            }
            finally
            {

            }
        }

        
    }
}
