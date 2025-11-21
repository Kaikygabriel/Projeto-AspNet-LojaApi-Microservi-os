using System.Security.Principal;
using Shop.Auth.Models.Abstraction;
using Shop.Auth.Models.ObjectValues;

namespace Shop.Auth.Models;

public class User : Entity
{
    protected User(){}
    public User(string name, string email, string passwordHash)
    {
        Name = name;
        Email = new Email(email);
        PasswordHash = passwordHash;
    }
    public User(string name, string? email)
    {
        Name = name;
        Email = new Email(email);
        Google = true;
    }

    public string Name { get; set; }
    public Email Email { get; set; }
    public string? PasswordHash { get; set; }
    public List<string> Roles { get;private set; } = new();
    public bool Google { get; set; }

    public void UpdateAddressInEmail(string address)
        => Email.SetAddress(address);

    public void SetRole(string role)
        => Roles.Add(role);

    public List<string> GetRoles()
        => Roles;
}