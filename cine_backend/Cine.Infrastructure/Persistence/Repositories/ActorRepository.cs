using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Movies;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class ActorRepository : IActorRepository
{
    private readonly CineDbContext _dbContext;

    public ActorRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Actor?> GetActorById(int Id)
    {
        return await _dbContext.Actors.SingleOrDefaultAsync(u => u.Id == Id);
    }
    public async Task<List<Actor>> GetActorList()
    {
        return await _dbContext.Actors.AsNoTracking().ToListAsync();
    }
}

