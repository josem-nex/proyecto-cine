using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IPointsPurchaseRepository
{
    Task Add(PointsPurchase PointsPurchase);
    Task<PointsPurchase?> GetPointsPurchaseById(int TicketId);
    Task Delete(PointsPurchase PointsPurchase);
    Task<List<PointsPurchase>> GetPointsPurchaseList();
    Task<PointsPurchase?> Update(PointsPurchase PointsPurchase);
}