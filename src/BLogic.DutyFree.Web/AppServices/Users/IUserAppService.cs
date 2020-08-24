using DutyFree.Core.Dtos;
using DutyFree.Core.Entities.Users;
using DutyFree.Web.ViewModels.Security;
using System.Threading.Tasks;

namespace DutyFree.Web.AppServices.Users
{
    public interface IUserAppService
    {
        IndexViewModel GetViewModel();

        Task<AccessTokenValidationResponseDto> ValidateIDToken(string accessToken);

        User LoginOrRegister(string validationToken);
    }
}