using AutoMapper;
using DTO;

namespace DAL.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<user, UserDTO>().ReverseMap();
        }
    }
}
