using ErrorOr;

namespace Cine.Domain.Entities;
public class Admin
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string User { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public Admin(string user, string password)
    {
        User = user;
        Password = password;
    }
    public void Update(string user, string password)
    {
        User = user;
        Password = password;
    }
}