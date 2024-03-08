namespace Cine.Domain.Entities;
public class Partner : User
{
    public string Address { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public int Points { get; private set; } = 0;
    public string Password { get; private set; } = null!;
    public Partner(string firstName, string lastName, string email, string ci, string address, string phoneNumber, string password)
        : base(firstName, lastName, email, ci)
    {
        Address = address;
        PhoneNumber = phoneNumber;
        Password = password;
    }
}