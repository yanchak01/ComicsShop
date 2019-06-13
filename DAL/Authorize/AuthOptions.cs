using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Authorize
{
    public class AuthOptions
    {
        public const string ISSURE = "DESKTOP-H9KC1CC";
        public const string AUDIENCE = "ComicsShop";
        const string KEY = "i_am_batman123";
        public const int LifeTime = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
