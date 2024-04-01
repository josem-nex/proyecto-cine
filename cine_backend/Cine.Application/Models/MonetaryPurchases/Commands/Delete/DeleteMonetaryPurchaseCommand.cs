using ErrorOr;
using MediatR;

namespace Cine.Application.Models.MonetaryPurchases.Commands;

public record DeleteMonetaryPurchaseCommand(int TicketId) : IRequest<ErrorOr<Unit>>;
