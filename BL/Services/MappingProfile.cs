using AuthorizationsAboutToken;
using AutoMapper;
using ComicsShop.DTO;
using DAL.DBModels;

namespace BLL.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Comics, ComicsDTO>().ReverseMap();
            CreateMap<LoginDTO, ApplicationUser>().ReverseMap();
            CreateMap<TokenRequest, LoginDTO>().ReverseMap();
            CreateMap<ArtistDTO, ComicsAuthor>().ReverseMap();
        }
    }
}
