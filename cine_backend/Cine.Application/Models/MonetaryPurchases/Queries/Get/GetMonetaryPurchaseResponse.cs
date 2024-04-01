namespace Cine.Application.Models.MonetaryPurchases.Queries;

public record GetMonetaryPurchaseResponse(Guid UserId, int TicketId, int TotalPrice, string CreditCard);
