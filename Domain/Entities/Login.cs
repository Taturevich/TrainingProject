namespace Domain.Entities
{
    public enum Roles
    {
        Admin,
        Guest,
        User,
        Courier
    }

    public class Login
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
