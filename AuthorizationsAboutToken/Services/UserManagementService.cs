using AuthorizationsAboutToken.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationsAboutToken.Services
{
    public class UserManagementService : IUserManagementService
    {
        public bool IsValidUser(string username, string password)
        {
            return true;
        }
    }
}
