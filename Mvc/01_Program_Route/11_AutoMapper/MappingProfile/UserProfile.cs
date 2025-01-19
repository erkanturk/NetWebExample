using _11_AutoMapper.Dto;
using _11_AutoMapper.Models;
using AutoMapper;

namespace _11_AutoMapper.MappingProfile
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            //User=>UserDto dönüşümünü tanımlıyoruz burada firtname ve lastname i fullname e maliyoruz.
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                $"{src.FirstName} {src.LastName}"));

            //UserDto=>User dönüşümünü tanımlıyoruz 
            // iki taraflı dönüşüm olabilir.
            CreateMap<UserDto, User>();
        }
    }
}
