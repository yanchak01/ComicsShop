﻿using AuthorizationsAboutToken.Interfaces;
using AuthorizationsAboutToken.Models;
using Microsoft.IdentityModel.Tokens;
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

        public AuthenticateService(IUserManagementService userManagementService,TokenManagemant tokenManagement)
        {
            this.userManagementService = userManagementService;
            this.tokenManagement = tokenManagement;

        }
        public bool IsAuthenticated(TokenRequest request, out string token)
        {
            token = string.Empty;

            if (!userManagementService.IsValidUser(request.Username, request.Password)) return false;
            var claim = new[]
           {
                new Claim(ClaimTypes.Name, request.Username)
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
