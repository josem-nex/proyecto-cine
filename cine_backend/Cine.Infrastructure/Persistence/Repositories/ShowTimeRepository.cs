using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class ShowTimeRepository : IShowTimeRepository
{
    private readonly CineDbContext _dbContext;

    public ShowTimeRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(ShowTime ShowTime)
    {
        await _dbContext.ShowTimes.AddAsync(ShowTime);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ShowTime?> GetShowTimeById(int Id)
    {
        return await _dbContext.ShowTimes.SingleOrDefaultAsync(u => u.Id == Id);
    }

    public async Task Delete(ShowTime ShowTime)
    {
        _dbContext.ShowTimes.Remove(ShowTime);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<ShowTime>> GetShowTimeList()
    {
        return _dbContext.ShowTimes.AsNoTracking().ToListAsync();
    }

    public async Task<ShowTime?> Update(ShowTime ShowTime)
    {
        _dbContext.ShowTimes.Update(ShowTime);
        await _dbContext.SaveChangesAsync();
        return ShowTime;
    }


}

