using DutyFree.Core.Dtos;
using DutyFree.Core.Entities.Users;
using DutyFree.Core.Repositories.Users;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DutyFree.Core.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private static readonly HttpClient Client = new HttpClient();

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<User> GetUsers()
        {
            var result = _userRepository.Users();

            return result as ICollection<User>;
        }

        public async Task<AccessTokenValidationResponseDto> ValidateIDToken(string idToken)
        {
            var userAccessTokenValidationResponse = new AccessTokenValidationResponseDto();
            try
            {
                userAccessTokenValidationResponse.AccessTokenResponse = await Client.GetStringAsync($"https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={idToken}");
                userAccessTokenValidationResponse.IsValid = true;
            }
            catch
            {
            }

            return userAccessTokenValidationResponse;
        }

        public User LoginOrRegister(string validationToken)
        {
            var googleUserAccessTokenData = JsonConvert.DeserializeObject<GoogleUserAccessTokenData>(validationToken);

            var user = _userRepository.FindByEmail(googleUserAccessTokenData.Email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = googleUserAccessTokenData.Given_Name,
                    LastName = googleUserAccessTokenData.Family_Name,
                    Email = googleUserAccessTokenData.Email,
                    ProfileImgUrl = googleUserAccessTokenData.Picture,
                    Role = Enums.Role.User
                };

                _userRepository.CreateUser(user);
            }

            return user;
        }
    }
}