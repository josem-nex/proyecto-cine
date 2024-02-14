namespace Cine.Contracts.Authentication;
public record AuthenticationResponse(
    Guid ID,
    string FirstName,
    string LastName,
    string Email,
    // int Points,
    string Token
);