using DutyFree.Core.Dtos;
using DutyFree.Core.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DutyFree.Core.Services.Users
{
    public interface IUserService
    {
        ICollection<User> GetUsers();

        Task<AccessTokenValidationResponseDto> ValidateIDToken(string accessToken);

        User LoginOrRegister(string validationToken);
    }
}
