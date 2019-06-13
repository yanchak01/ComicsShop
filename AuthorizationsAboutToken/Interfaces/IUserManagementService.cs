using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationsAboutToken.Interfaces
{
    public interface IUserManagementService
    {
        bool IsValidUser(string username, string password);
    }
}
