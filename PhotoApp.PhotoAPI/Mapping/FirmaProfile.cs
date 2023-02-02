using AutoMapper;
using DTO.DtoModel;
using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.PhotoAPI.Mapping
{
    public class FirmaProfile : Profile
    {
        public FirmaProfile()
        {
            CreateMap<Firma, FirmaDto.FirmaUser>().ReverseMap();
            CreateMap<Firma, FirmaDto.Firma>().ReverseMap();
            CreateMap<User, FirmaDto.FirmaUser>().ReverseMap();
            //CreateMap<Firma, FirmaDto.Firma>()
            //.ForMember(dest => dest.FirmaID, opt => opt.MapFrom(x => x.ID)).ReverseMap(); //dto önde model ikinci sıradaki
            //.ForMember(dest => dest.FirmaAdi, opt => opt.MapFrom(x => x.FirmaAdi)); 
        }
    }
}
