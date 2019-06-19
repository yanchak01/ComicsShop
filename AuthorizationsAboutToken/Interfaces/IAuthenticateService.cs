using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationsAboutToken.Interfaces
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(TokenRequest request, out string token);
        Task<ClaimsIdentity> GetIdentity(string userName, string password);
        string GenerateToken(ClaimsIdentity identity);
    }
}
