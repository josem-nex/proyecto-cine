using ErrorOr;
using MediatR;

namespace Cine.Application.Models.MonetaryPurchases.Queries;

public record GetMonetaryPurchaseQuery(int TicketId) : IRequest<ErrorOr<GetMonetaryPurchaseResult>>;
