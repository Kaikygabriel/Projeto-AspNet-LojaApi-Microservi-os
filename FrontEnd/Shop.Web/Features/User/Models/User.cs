namespace Shop.Web.User.Models;

public class User
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new();
}