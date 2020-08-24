using DutyFree.Core.Entities.Users;
using DutyFree.Core.Repositories.Users;
using DutyFree.Data.EntityFramework;
using DutyFree.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace DutyFree.Data.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBConnectionFactory _connectionFactory;
        private readonly DataContext _dataContext;

        public UserRepository(IDBConnectionFactory connectionFactory, DataContext dataContext)
        {
            _connectionFactory = connectionFactory;
            _dataContext = dataContext;
        }

        public IEnumerable<User> Users()
        {
            var users = _dataContext
                .Users
                .AsNoTracking()
                .ToList();

            return users;
        }

        public User FindByEmail(string email)
        {
            var user = _dataContext
                .Users
                .Where(u => u.Email == email)
                .FirstOrDefault();

            return user;
        }

        public User CreateUser(User user)
        {
            _dataContext
                .Users
                .Add(user);

            _dataContext.SaveChanges();

            return user;
        }
    }
}
