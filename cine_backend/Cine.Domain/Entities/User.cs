namespace Cine.Domain.Entities;

public class User{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    // public string CI { get; set; } = null!;
    // public string Address { get; set; } = null!;
    // public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
}