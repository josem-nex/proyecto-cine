using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class MonetaryPurchaseRepository : IMonetaryPurchaseRepository
{
    private readonly CineDbContext _dbContext;

    public MonetaryPurchaseRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(MonetaryPurchase MonetaryPurchase)
    {
        await _dbContext.MonetaryPurchases.AddAsync(MonetaryPurchase);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<MonetaryPurchase?> GetMonetaryPurchaseById(int TicketId)
    {
        return await _dbContext.MonetaryPurchases.SingleOrDefaultAsync(u => u.TicketsId == TicketId);
    }

    public async Task Delete(MonetaryPurchase MonetaryPurchase)
    {
        _dbContext.MonetaryPurchases.Remove(MonetaryPurchase);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<MonetaryPurchase>> GetMonetaryPurchaseList()
    {
        return _dbContext.MonetaryPurchases.AsNoTracking().ToListAsync();
    }

    public async Task<MonetaryPurchase?> Update(MonetaryPurchase MonetaryPurchase)
    {
        _dbContext.MonetaryPurchases.Update(MonetaryPurchase);
        await _dbContext.SaveChangesAsync();
        return MonetaryPurchase;
    }


}
