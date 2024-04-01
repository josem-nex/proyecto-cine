using ErrorOr;
using MediatR;
namespace Cine.Application.Models.PointsPurchases.Commands;

public record AddPointsPurchaseCommand(Guid UserId, int TicketId, int TotalPoints) : IRequest<ErrorOr<GetPointsPurchaseResult>>;
