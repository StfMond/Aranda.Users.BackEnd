namespace Aranda.Users.BackEnd.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public decimal? Telephone { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
