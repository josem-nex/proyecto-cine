using Cine.Application.Authentication.Common;
using ErrorOr;
using MediatR;
namespace Cine.Application.Authentication.Commands.Update;
public record UpdatePartnerCommand(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string Ci,
    string Address,
    string PhoneNumber,
    string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;