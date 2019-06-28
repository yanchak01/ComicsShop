using AuthorizationsAboutToken;
using AutoMapper;
using ComicsShop.DTO;
using DAL.DBModels;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ComicsDTO, Comics>()
                .ForMember(x => x.Authors, x => x.MapFrom(src => src.ComicsAuthors.Select(y => new ComicsAuthorComics
                {
                    ComicsId = src.Id,
                    ComicsAuthorId = y.Id
                })));

            CreateMap<Comics, ComicsDTO>()
                .ForMember(x => x.ComicsAuthors, x => x.MapFrom(src => src.Authors.Select(a=>a.ComicsAuthor)));
            CreateMap<LoginDTO, ApplicationUser>().ReverseMap();
            CreateMap<TokenRequest, LoginDTO>().ReverseMap();
            CreateMap<ComicsAuthorDTO, ComicsAuthor>().ReverseMap();
            CreateMap<ComicsDTO, ComicsAuthorDTO>().ReverseMap();
            CreateMap<ComicsAuthorDTO, ComicsAuthorComics>()
               .ForMember(x => x.ComicsAuthorId, x => x.MapFrom(src => src.Id));
            CreateMap<ComicsDTO, ComicsAuthorComics>()
                .ForMember(x => x.ComicsId, x => x.MapFrom(src => src.Id));
            
        }
        
    }
}
