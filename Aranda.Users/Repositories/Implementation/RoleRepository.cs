using System.Collections.Generic;
using System.Linq;
using Aranda.Users.BackEnd.Models;
using Aranda.Users.BackEnd.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace Aranda.Users.BackEnd.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly Aranda_User_Context _context;

        public RoleRepository(Aranda_User_Context context)
        {
            _context = context;
        }
        public IEnumerable<Role> GetAll()
        {
            return _context.Role.AsEnumerable();
        }

        public Role GetPermissionsByRol(int rolId)
        {
            return _context.Role
                .Include(x => x.RolePermission)
                .ThenInclude(x => x.Permission)
                .FirstOrDefault(x => x.Id == rolId);
        }

        public Role GetRolById(int rolId)
        {
            return _context.Role.FirstOrDefault(x => x.Id == rolId);
        }
    }
}
