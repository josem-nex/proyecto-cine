namespace Cine.Application.Models.PointsPurchases;

public record GetPointsPurchaseResponse(Guid UserId, int TicketId, int TotalPoints);
