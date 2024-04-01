using ErrorOr;
using MediatR;
namespace Cine.Application.Models.PointsPurchases.Commands;

public record UpdatePointsPurchaseCommand(Guid UserId, int TicketId, int TotalPoints) : IRequest<ErrorOr<GetPointsPurchaseResult>>;
