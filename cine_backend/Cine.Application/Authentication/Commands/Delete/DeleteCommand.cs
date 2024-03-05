using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Commands.Delete;
public record DeleteCommand(string Email) : IRequest<ErrorOr<Unit>>;