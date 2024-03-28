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
        // return _dbContext.Movies.Include(m => m.Country).AsNoTracking().ToListAsync();
    }

    public async Task Update(Movie movie)
    {

        // Obtén todos los actores y géneros necesarios en una sola consulta
        var actorIds = movie.Actors.Select(a => a.Id).ToList();
        var genreIds = movie.Genres.Select(g => g.Id).ToList();
        var actors = await _dbContext.Actors.Where(a => actorIds.Contains(a.Id)).ToListAsync();
        var genres = await _dbContext.Genres.Where(g => genreIds.Contains(g.Id)).ToListAsync();

        // Obtén la película a actualizar
        var movieToUpdate = await _dbContext.Movies
            .Include(m => m.Actors)
            .Include(m => m.Genres)
            .Include(m => m.Country)
            .SingleOrDefaultAsync(m => m.Id == movie.Id);

        // Actualiza las propiedades de la película
        _dbContext.Entry(movieToUpdate).CurrentValues.SetValues(movie);

        // Actualiza las relaciones con actores y géneros
        movieToUpdate.Actors.Clear();
        movieToUpdate.Actors.AddRange(actors);
        movieToUpdate.Genres.Clear();
        movieToUpdate.Genres.AddRange(genres);

        await _dbContext.SaveChangesAsync();

        /* List<Actor> actors = new();
        List<Genre> genres = new();
        foreach (var idActor in movie.Actors)
        {
            var actor = await _dbContext.Actors.SingleOrDefaultAsync(a => a.Id == idActor.Id);
            if (actor != null)
            {
                actors.Add(actor);
            }
        }
        foreach (var idGenre in movie.Genres)
        {
            var genre = await _dbContext.Genres.SingleOrDefaultAsync(g => g.Id == idGenre.Id);
            if (genre != null)
            {
                genres.Add(genre);
            }
        }
        var movieToUpdate = await _dbContext.Movies
            .Include(m => m.Actors)
            .Include(m => m.Genres)
            .Include(m => m.Country)
            .SingleOrDefaultAsync(m => m.Id == movie.Id);

        movieToUpdate.Actors.Clear();
        movieToUpdate.Genres.Clear();

        for (int i = 0; i < actors.Count; i++)
            movieToUpdate.Actors.Add(actors[i]);
        for (int i = 0; i < genres.Count; i++)
            movieToUpdate.Genres.Add(genres[i]);


        // _dbContext.Movies.Update(movieToUpdate);
        await _dbContext.SaveChangesAsync(); */
    }
}