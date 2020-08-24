using DutyFree.Core.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DutyFree.Core.Repositories.Users
{
    public interface IUserRepository
    {
        IEnumerable<User> Users();

        User FindByEmail(string email);

        User CreateUser(User user);
    }
}
