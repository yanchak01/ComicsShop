using AuthorizationsAboutToken.Interfaces;
using AutoMapper;
using DAL.DBModels;
using Microsoft.AspNetCore.Identity;
using ComicsShop.DTO;
using OtherLogic.IRepo;

namespace AuthorizationsAboutToken.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IBaseRepository<ApplicationUser> baseRepositore;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;
        public UserManagementService(IBaseRepository<ApplicationUser> baseRepositore, 
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper
            )
        {
            this.baseRepositore = baseRepositore;
            this.userManager = userManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
        }

        
        public  bool IsValidUser(LoginDTO loginDTO)
        {
            var usering = mapper.Map<LoginDTO, ApplicationUser>(loginDTO);

            var user = userManager.FindByNameAsync(loginDTO.UserName).Result;
            
            var UserCheck = userManager.CheckPasswordAsync(user, loginDTO.Password).Result;
            if (UserCheck == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
