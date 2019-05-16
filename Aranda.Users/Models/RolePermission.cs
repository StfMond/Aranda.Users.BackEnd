namespace Aranda.Users.BackEnd.Models
{
    public partial class RolePermission
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Rol { get; set; }
    }
}
