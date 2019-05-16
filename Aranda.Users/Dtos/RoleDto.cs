using System.Collections.Generic;

namespace Aranda.Users.BackEnd.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PermissionDto> RolePermission { get; set; }
    }
}
