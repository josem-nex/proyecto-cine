using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class ChairRepository : IChairRepository
{
    private readonly CineDbContext _dbContext;

    public ChairRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Chair?> GetChairById(int Id)
    {
        return await _dbContext.Chairs.SingleOrDefaultAsync(u => u.Id == Id);
    }
    public async Task<List<Chair>> GetChairList()
    {
        return await _dbContext.Chairs.AsNoTracking().ToListAsync();
    }

}

