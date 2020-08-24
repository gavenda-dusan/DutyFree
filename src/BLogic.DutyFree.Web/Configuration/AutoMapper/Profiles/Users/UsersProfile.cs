using AutoMapper;
using DutyFree.Core.Entities.Users;
using DutyFree.Web.ViewModels.Security;

namespace DutyFree.Web.Configuration.AutoMapper.Profiles.Users
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID)).ReverseMap();
        }
    }
}