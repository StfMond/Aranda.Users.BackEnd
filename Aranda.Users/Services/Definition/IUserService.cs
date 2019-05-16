using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aranda.Users.BackEnd.Dtos;
using Aranda.Users.BackEnd.Models;

namespace Aranda.Users.BackEnd.Services.Definition
{
    public interface IUserService
    {
        UserDataDto GetUser(string userName, string password);

       IEnumerable<UserDto> GetAll(Func<User, bool> filter);

       UserDto AddUser(UserDto user);

       Task<UserDto> UpdateUser(UserDto user);

       bool DeleteUser(int userId);
    }
}
