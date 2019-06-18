using AuthorizationsAboutToken.Interfaces;
using AuthorizationsAboutToken.Models;
using AutoMapper;
using DAL.DBModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthorizationsAboutToken.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserManagementService userManagementService;
        private readonly TokenManagemant tokenManagement;
        private readonly IMapper mapper;

        public AuthenticateService(IUserManagementService userManagementService, IOptions<TokenManagemant> tokenManagement, IMapper mapper )
        {
            this.userManagementService = userManagementService;
            this.tokenManagement = tokenManagement.Value;
            this.mapper = mapper;
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
    }
}
