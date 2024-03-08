using Cine.Domain.Entities;
namespace Cine.Application.Authentication.Common;
public record AuthenticationResult(
    Partner Partner,
    string Token);