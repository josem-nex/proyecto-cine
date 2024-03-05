namespace Cine.Contracts.Authentication;

public record DeleteUserRequest(
    string Email,
    string Password);
