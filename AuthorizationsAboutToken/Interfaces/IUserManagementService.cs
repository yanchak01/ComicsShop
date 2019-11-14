using ComicsShop.DTO;

namespace AuthorizationsAboutToken.Interfaces
{
    public interface IUserManagementService
    {
        bool IsValidUser(LoginDTO loginDTO);
    }
}
