using DutyFree.Core.Dtos;
using DutyFree.Core.Entities.Users;
using DutyFree.Core.Services.Users;
using DutyFree.Web.Configuration.AutoMapper.Mappers.Users;
using DutyFree.Web.ViewModels.Security;
using System.Threading.Tasks;

namespace DutyFree.Web.AppServices.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IUsersMapper _userMapper;

        public UserAppService(IUserService userService, IUsersMapper userMapper)
        {
            _userService = userService;
            _userMapper = userMapper;
        }

        public IndexViewModel GetViewModel()
        {
            return new IndexViewModel { Users = _userMapper.GetUserViewModels(_userService.GetUsers()) };
        }

        public async Task<AccessTokenValidationResponseDto> ValidateIDToken(string idToken)
        {
            return await _userService.ValidateIDToken(idToken);
        }

        public User LoginOrRegister(string validationToken)
        {
            return _userService.LoginOrRegister(validationToken);
        }
    }
}