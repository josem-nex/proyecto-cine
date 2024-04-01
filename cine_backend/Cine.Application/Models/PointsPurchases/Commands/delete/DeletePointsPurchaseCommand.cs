using ErrorOr;
using MediatR;
namespace Cine.Application.Models.PointsPurchases.Commands;
public record DeletePointsPurchaseCommand(int TicketId) : IRequest<ErrorOr<Unit>>;
