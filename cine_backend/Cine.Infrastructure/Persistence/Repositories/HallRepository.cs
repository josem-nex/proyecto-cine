using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class HallRepository : IHallRepository
{
    private readonly CineDbContext _dbContext;

    public HallRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Hall Hall)
    {
        await _dbContext.Halls.AddAsync(Hall);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Hall?> GetHallById(int Id)
    {
        return await _dbContext.Halls.SingleOrDefaultAsync(u => u.Id == Id);
    }
    public async Task<Hall?> GetHallByName(string name)
    {
        return await _dbContext.Halls.SingleOrDefaultAsync(u => u.Name == name);
    }

    public async Task Delete(Hall Hall)
    {
        _dbContext.Halls.Remove(Hall);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<Hall>> GetHallList()
    {
        return _dbContext.Halls.AsNoTracking().ToListAsync();
    }

    public async Task<Hall?> Update(Hall Hall)
    {
        _dbContext.Halls.Update(Hall);
        await _dbContext.SaveChangesAsync();
        return Hall;
    }


}

