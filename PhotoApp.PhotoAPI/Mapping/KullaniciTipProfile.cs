using AutoMapper;
using DTO.DtoModel;
using PhotoApp.Entities.Models;

namespace PhotoApp.PhotoAPI.Mapping
{
    public class KullaniciTipProfile : Profile
    {
        public KullaniciTipProfile()
        {
            CreateMap<KullaniciTip, KullaniciTipDto>().ReverseMap();
           // CreateMap<KullaniciTip, KullaniciTipDto>()
           //.ForMember(dest => dest.Tip, opt => opt.MapFrom(x => x.Tip));
        }
    }
}
