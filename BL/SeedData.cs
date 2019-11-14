using ComicsShop.DAL;
using DAL.DBModels;
using Microsoft.AspNetCore.Identity;

namespace ComicsShop.BLL
{
    public static class SeedData
    {
        public static void Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            MyIdentityDataInitializer.SeedData(userManager,roleManager);
        }
    }
}
