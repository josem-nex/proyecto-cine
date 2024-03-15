using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Cine.Domain.Entities.Movies;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class MoviesRepository /* : IMoviesRepository */
{
    private readonly CineDbContext _dbContext;

    public MoviesRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Movie Movies)
    {
        _dbContext.Movies.Add(Movies);
        _dbContext.SaveChanges();
    }

    public Movie? GetMoviesById(int Id)
    {
        return _dbContext.Movies.SingleOrDefault(u => u.Id == Id);
    }

    public void Delete(int Id)
    {
        var Movie = _dbContext.Movies.SingleOrDefault(u => u.Id == Id);
        _dbContext.Movies.Remove(Movie);
        _dbContext.SaveChanges();
    }

    public List<Movie> GetMoviesList()
    {
        return _dbContext.Movies.AsNoTracking().ToList();
    }

    public void Update(Movie Movies)
    {
        _dbContext.Movies.Update(Movies);
        _dbContext.SaveChanges();
    }
}