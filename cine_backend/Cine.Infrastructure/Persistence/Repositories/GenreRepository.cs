using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Movies;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class GenreRepository : IGenreRepository
{
    private readonly CineDbContext _dbContext;

    public GenreRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Genre?> GetGenreById(int Id)
    {
        return await _dbContext.Genres.SingleOrDefaultAsync(u => u.Id == Id);
    }
    public async Task<List<Genre>> GetGenreList()
    {
        return await _dbContext.Genres.AsNoTracking().ToListAsync();
    }

}

