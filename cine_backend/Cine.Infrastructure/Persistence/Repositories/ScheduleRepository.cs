using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class ScheduleRepository : IScheduleRepository
{
    private readonly CineDbContext _dbContext;

    public ScheduleRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Schedule Schedule)
    {
        await _dbContext.Schedules.AddAsync(Schedule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Schedule?> GetScheduleById(int Id)
    {
        return await _dbContext.Schedules.SingleOrDefaultAsync(u => u.Id == Id);
    }

    public async Task Delete(Schedule Schedule)
    {
        _dbContext.Schedules.Remove(Schedule);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<Schedule>> GetScheduleList()
    {
        return _dbContext.Schedules.AsNoTracking().ToListAsync();
    }

    public async Task<Schedule?> Update(Schedule Schedule)
    {
        _dbContext.Schedules.Update(Schedule);
        await _dbContext.SaveChangesAsync();
        return Schedule;
    }


}

