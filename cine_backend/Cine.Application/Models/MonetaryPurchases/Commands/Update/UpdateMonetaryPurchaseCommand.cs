using Cine.Application.Models.MonetaryPurchases.Queries;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.MonetaryPurchases.Commands;

public record UpdateMonetaryPurchaseCommand(Guid UserId, int TicketId, int TotalPrice, string CreditCard) : IRequest<ErrorOr<GetMonetaryPurchaseResult>>;
