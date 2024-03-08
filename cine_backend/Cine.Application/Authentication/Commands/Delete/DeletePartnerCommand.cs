using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Commands.Delete;
public record DeletePartnerCommand(string Email, string Password) : IRequest<ErrorOr<Unit>>;