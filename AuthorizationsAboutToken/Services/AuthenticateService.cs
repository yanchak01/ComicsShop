using AuthorizationsAboutToken.Interfaces;
using AuthorizationsAboutToken.Models;
using AutoMapper;
using DAL.DBModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationsAboutToken.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserManagementService userManagementService;
        private readonly TokenManagemant tokenManagement;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthenticateService(IUserManagementService userManagementService, 
            IOptions<TokenManagemant> tokenManagement, 
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManagementService = userManagementService;
            this.tokenManagement = tokenManagement.Value;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public bool IsAuthenticated(TokenRequest request, out string token)
        {
            token = string.Empty;

            var user = mapper.Map<TokenRequest, LoginDTO>(request);

            if (!userManagementService.IsValidUser(user)) { return false; }
            else
            {
                var claim = new[]
               {
                new Claim(ClaimTypes.Name, request.UserName)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityToken(
                    tokenManagement.Issuer,
                    tokenManagement.Audience,
                    claim,
                    expires: DateTime.Now.AddMinutes(tokenManagement.AccessExpiration),
                    signingCredentials: credentials
                );
                token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                return true;
            }
        }

        public string GenerateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                tokenManagement.Issuer,
                tokenManagement.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: DateTime.Now.AddMinutes(tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            var tokenjwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return $"Bearer {tokenjwt}";
        }

        public async Task<ClaimsIdentity> GetIdentity(string userName, string password)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new Exception("The user not found");
            }

            var result = await signInManager.PasswordSignInAsync(user.UserName, password, false, false);
            if (result.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);


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
    }
}
