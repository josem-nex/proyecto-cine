using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Commands.Delete;
public record DeleteUserCommand(string Email, string Password) : IRequest<ErrorOr<Unit>>;