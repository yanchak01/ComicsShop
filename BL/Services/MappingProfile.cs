using AuthorizationsAboutToken;
using AutoMapper;
using ComicsShop.DTO;
using DAL.DBModels;
using System.Collections.Generic;

namespace BLL.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ComicsDTO, Comics>()
                .ForMember(x => x.Authors, cx => cx.MapFrom(ux => ux.ComicsAuthors));
            CreateMap<Comics,ComicsDTO>()
                 .ForMember(x => x.ComicsAuthors, cx => cx.MapFrom(ux => ux.Authors));
            CreateMap<LoginDTO, ApplicationUser>().ReverseMap();
            CreateMap<TokenRequest, LoginDTO>().ReverseMap();
            CreateMap<ComicsAuthorDTO, ComicsAuthor>().ReverseMap();
            //CreateMap<IEnumerable<ComicsAuthorDTO>, IEnumerable<ComicsAuthor>>().ReverseMap();
            CreateMap<ComicsDTO, ComicsAuthorDTO>().ReverseMap();
                
        }
       
    }
}
