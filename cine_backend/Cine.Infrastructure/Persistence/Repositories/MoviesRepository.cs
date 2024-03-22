using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Cine.Domain.Entities.Movies;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class MovieRepository : IMovieRepository
{
    private readonly CineDbContext _dbContext;

    public MovieRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Movie movie)
    {
        await _dbContext.Movies.AddAsync(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Movie?> GetMovieById(int Id)
    {
        return await _dbContext.Movies.SingleOrDefaultAsync(u => u.Id == Id);
    }
    public async Task<Movie?> GetMovieByTitle(string title)
    {
        return await _dbContext.Movies.SingleOrDefaultAsync(u => u.Title == title);
    }

    public async Task Delete(Movie movie)
    {
        _dbContext.Movies.Remove(movie);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<Movie>> GetMovieList()
    {
        return _dbContext.Movies.AsNoTracking().ToListAsync();
    }

    public async Task Update(Movie movie)
    {
        _dbContext.Movies.Update(movie);
        await _dbContext.SaveChangesAsync();
    }
}