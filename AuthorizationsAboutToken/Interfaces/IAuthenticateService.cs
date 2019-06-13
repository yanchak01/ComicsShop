using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationsAboutToken.Interfaces
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(TokenRequest request, out string token);
    }
}
