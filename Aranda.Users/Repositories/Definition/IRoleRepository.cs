using System.Collections.Generic;
using Aranda.Users.BackEnd.Models;

namespace Aranda.Users.BackEnd.Repositories.Definition
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();

        Role GetPermissionsByRol(int rolId);

        Role GetRolById(int rolId);
    }
}
