namespace Cine.Application.Models.PointsPurchases.Commands;


public record UpdatePointsPurchaseRequest(Guid UserId, int TicketId, int TotalPoints);
