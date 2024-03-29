using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Commands.Delete;
public record DeletePartnerCommand(Guid Id) : IRequest<ErrorOr<Unit>>;