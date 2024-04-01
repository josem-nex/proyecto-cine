namespace Cine.Application.Models.PointsPurchases.Commands;
public record AddPointsPurchaseRequest(Guid UserId, int TicketId, int TotalPoints);
