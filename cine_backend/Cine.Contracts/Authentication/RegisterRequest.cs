namespace Cine.Contracts.Authentication;
public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string CI,
    string PhoneNumber,
    string Address);