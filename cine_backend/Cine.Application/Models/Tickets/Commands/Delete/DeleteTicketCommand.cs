using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Tickets.Commands;

public record DeleteTicketCommand(int Id) : IRequest<ErrorOr<Unit>>;
