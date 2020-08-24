using DutyFree.Core.Entities.Users;
using DutyFree.Web.ViewModels.Security;
using System.Collections.Generic;

namespace DutyFree.Web.Configuration.AutoMapper.Mappers.Users
{
    public interface IUsersMapper
    {
        UserViewModel GetUserViewModel(User entity);

        User GetUserEntity(UserViewModel viewModel);

        ICollection<UserViewModel> GetUserViewModels(ICollection<User> users);
    }
}