using Microsoft.VisualBasic;

namespace Cine.Domain.Entities;

public class Partner
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Ci { get; private set; } = null!;
    public string Address { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public int Points { get; private set; } = 0;
    public string Password { get; private set; } = null!;
    public Partner(string firstName, string lastName, string email, string ci, string address, string phoneNumber, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Ci = ci;
        Address = address;
        PhoneNumber = phoneNumber;
        Password = password;
    }
}