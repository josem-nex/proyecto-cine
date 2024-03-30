using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class DiscountRepository : IDiscountRepository
{
    private readonly CineDbContext _dbContext;

    public DiscountRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Discount?> GetDiscountById(int Id)
    {
        return await _dbContext.Discounts.SingleOrDefaultAsync(u => u.Id == Id);
    }
    public async Task<List<Discount>> GetDiscountList()
    {
        return await _dbContext.Discounts.AsNoTracking().ToListAsync();
    }

}

