using AuthorizationsAboutToken;
using AutoMapper;
using DAL.DBModels;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
   public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Comics, ComicsDTO>().ReverseMap();
            CreateMap<LoginDTO, ApplicationUser>().ReverseMap();
            CreateMap<TokenRequest, LoginDTO>().ReverseMap();
        }
    }
}
