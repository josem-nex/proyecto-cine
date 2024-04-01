namespace Cine.Application.Models.MonetaryPurchases.Commands;

public record AddMonetaryPurchaseRequest(Guid UserId, int TicketId, int TotalPrice, string CreditCard);
