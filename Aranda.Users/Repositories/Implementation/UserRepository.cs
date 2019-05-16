using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aranda.Users.BackEnd.Models;
using Aranda.Users.BackEnd.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace Aranda.Users.BackEnd.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly Aranda_User_Context _context;

        public UserRepository(Aranda_User_Context context)
        {
            _context = context;
        }

        public User GetUser(string userName, string password)
        {
            return _context.User
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Name.Equals(userName) && x.Password.Equals(password));
        }

        public IEnumerable<User> GetAll(Func<User, bool> filter)
        {
            return _context.User.Include(x => x.Role)
                .Where(filter)
                .AsEnumerable();
        }

        public User AddUser(User user)
        {
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User> UpdateUser(User userData)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == userData.Id);
            if (user == null) return null;
            user.Name = userData.Name;
            user.FullName = userData.FullName;
            user.Address = userData.Address;
            user.Telephone = userData.Telephone;
            user.Email = userData.Email;
            user.Age = userData.Age;
            user.RoleId = userData.RoleId;
            user.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return user;
        }


        public bool DeleteUser(int userId)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == userId);
            if (user == null) return false;
            _context.User.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
