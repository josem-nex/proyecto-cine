using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class PointsPurchaseRepository : IPointsPurchaseRepository
{
    private readonly CineDbContext _dbContext;

    public PointsPurchaseRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(PointsPurchase PointsPurchase)
    {
        await _dbContext.PointsPurchases.AddAsync(PointsPurchase);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PointsPurchase?> GetPointsPurchaseById(int TicketId)
    {
        return await _dbContext.PointsPurchases.SingleOrDefaultAsync(u => u.TicketsId == TicketId);
    }

    public async Task Delete(PointsPurchase PointsPurchase)
    {
        _dbContext.PointsPurchases.Remove(PointsPurchase);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<PointsPurchase>> GetPointsPurchaseList()
    {
        return _dbContext.PointsPurchases.AsNoTracking().ToListAsync();
    }

    public async Task<PointsPurchase?> Update(PointsPurchase PointsPurchase)
    {
        _dbContext.PointsPurchases.Update(PointsPurchase);
        await _dbContext.SaveChangesAsync();
        return PointsPurchase;
    }


}
