using Cine.Domain.Entities;

namespace Cine.Application.Services.Authentication;
public record AuthenticationResult(
    User User, 
    string Token);