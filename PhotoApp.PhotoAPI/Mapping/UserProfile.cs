using AutoMapper;
using DTO.DtoModel;
using PhotoApp.Entities.Models;

namespace PhotoApp.PhotoAPI.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, FirmaDto.FirmaUser>().ReverseMap();
            CreateMap<User, UserDto.User>().ReverseMap();

        }
    }
}
