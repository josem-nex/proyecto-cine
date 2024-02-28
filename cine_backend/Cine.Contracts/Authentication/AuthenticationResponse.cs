namespace Cine.Contracts.Authentication;
public record AuthenticationResponse(
    Guid ID,
    string FirstName,
    string LastName,
    string Email,
    string CI,
    string Address,
    string PhoneNumber,
    int Points,
    string Token
);