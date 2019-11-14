using DAL.DBModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComicsShop.DAL
{
    public class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] Roles = { RolesEnum.Admin.ToString(), RolesEnum.ComicsSeller.ToString(), RolesEnum.User.ToString() };
            foreach (var role in Roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    IdentityRole role1 = new IdentityRole();
                    role1.Name = role;
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role1).Result;
                }
            }

        }

        
    }
}
