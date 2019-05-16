using System.Collections.Generic;
using Aranda.Users.BackEnd.Dtos;

namespace Aranda.Users.BackEnd.Services.Definition
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();

        RoleDto GetPermissionsByRol(int rolId);
    }
}
