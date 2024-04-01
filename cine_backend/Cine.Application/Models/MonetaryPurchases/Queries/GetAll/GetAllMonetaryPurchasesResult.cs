using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Models.MonetaryPurchases.Queries;

public record GetAllMonetaryPurchasesResult(List<MonetaryPurchase> MonetaryPurchases);
