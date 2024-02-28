using Cine.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Querys.Login;
public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;