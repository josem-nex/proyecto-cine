namespace Cine.Contracts.Authentication;
public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Ci,
    string Address,
    string PhoneNumber,
    string Password
    );