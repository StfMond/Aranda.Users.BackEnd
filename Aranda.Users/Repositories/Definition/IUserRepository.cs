using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aranda.Users.BackEnd.Models;

namespace Aranda.Users.BackEnd.Repositories.Definition
{
    public interface IUserRepository
    {
        User GetUser(string userName, string password);

        IEnumerable<User> GetAll(Func<User, bool> filter);

        User AddUser(User user);

        Task<User> UpdateUser(User user);

        bool DeleteUser(int userId);
    }
}
