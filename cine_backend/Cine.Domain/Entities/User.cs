namespace Cine.Domain.Entities;
public class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Ci { get; private set; } = null!;
    public User(string firstName, string lastName, string email, string ci)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Ci = ci;
    }
    public void Update(string firstName, string lastName, string email, string ci)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Ci = ci;
    }
}