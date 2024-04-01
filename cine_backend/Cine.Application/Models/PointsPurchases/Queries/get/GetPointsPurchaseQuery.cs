using ErrorOr;
using MediatR;

namespace Cine.Application.Models.PointsPurchases;

public record GetPointsPurchaseQuery(int TicketId) : IRequest<ErrorOr<GetPointsPurchaseResult>>;
