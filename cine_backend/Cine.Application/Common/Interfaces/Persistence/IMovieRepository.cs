using Cine.Domain.Entities.Movies;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IMovieRepository
{
    Task Add(Movie movie);
    Task Update(Movie movie);
    Task Delete(Movie movie);
    Task<Movie?> GetMovieById(int ID);
    Task<List<Movie>> GetMovieList();
    Task<Movie?> GetMovieByTitle(string title);
    Task<List<int>> GetGenresByMovie(int Id);
    Task<List<int>> GetActorsByMovie(int Id);
    Task<List<int>> GetShowtimesByMovie(int Id);

}
