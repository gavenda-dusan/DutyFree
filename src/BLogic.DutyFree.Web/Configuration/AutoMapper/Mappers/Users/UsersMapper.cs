using AutoMapper;
using DutyFree.Core.Entities.Users;
using DutyFree.Web.ViewModels.Security;
using System.Collections.Generic;

namespace DutyFree.Web.Configuration.AutoMapper.Mappers.Users
{
    public class UsersMapper : IUsersMapper
    {
        private readonly IMapper _mapper;

        public UsersMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserViewModel GetUserViewModel(User entity)
        {
            return _mapper.Map<UserViewModel>(entity);
        }

        public User GetUserEntity(UserViewModel viewModel)
        {
            return _mapper.Map<User>(viewModel);
        }

        public ICollection<UserViewModel> GetUserViewModels(ICollection<User> users)
        {
            return _mapper.Map<ICollection<UserViewModel>>(users);
        }
    }
}