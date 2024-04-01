namespace Cine.Application.Models.MonetaryPurchases.Commands;

public record UpdateMonetaryPurchaseRequest(Guid UserId, int TicketId, int TotalPrice, string CreditCard);
