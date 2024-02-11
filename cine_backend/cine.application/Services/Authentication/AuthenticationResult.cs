namespace Cine.Application.Services.Authentication;
public record AuthenticationResult(
    Guid ID, 
    string Firstname, 
    string Lastname, 
    string Email, 
    int Points, 
    string Token);