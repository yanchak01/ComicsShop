using ComicsShop.DTO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationsAboutToken.Interfaces
{
    public interface IAuthentificationService
    {
        Task<ClaimsIdentity> GetIdentity(string userName, string password);
        string GenerateToken(ClaimsIdentity identity);
         Task Registration(RegistrationDTO registrationDRO,bool ModelState);
    }
}
