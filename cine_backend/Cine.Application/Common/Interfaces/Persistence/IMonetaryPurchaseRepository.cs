using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IMonetaryPurchaseRepository
{
    Task Add(MonetaryPurchase MonetaryPurchase);
    Task<MonetaryPurchase?> GetMonetaryPurchaseById(int TicketId);
    Task Delete(MonetaryPurchase MonetaryPurchase);
    Task<List<MonetaryPurchase>> GetMonetaryPurchaseList();
    Task<MonetaryPurchase?> Update(MonetaryPurchase MonetaryPurchase);
}