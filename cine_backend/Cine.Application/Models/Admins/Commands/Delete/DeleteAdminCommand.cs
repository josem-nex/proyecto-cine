using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Admins.Commands;

public record DeleteAdminCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
