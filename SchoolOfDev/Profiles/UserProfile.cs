using AutoMapper;
using SchoolOfDev.DTO.User;
using SchoolOfDev.Entities;

namespace SchoolOfDev.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRequest>();
            CreateMap<User, UserRequestUpdate>();
            CreateMap<User, UserResponse>();
        }
    }
}
