using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Common.Interfaces.Persistence;
public interface IDiscountRepository
{
    Task<Discount?> GetDiscountById(int Id);
    Task<List<Discount>> GetDiscountList();
}