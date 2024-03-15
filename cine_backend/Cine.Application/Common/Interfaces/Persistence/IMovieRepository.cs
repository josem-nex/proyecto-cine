using Cine.Domain.Entities.Movies;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IMovieRepository
{
    Task Add(Movie movie);
    Task Update(Movie movie);
    Task Delete(int Id);
    Task<Movie?> GetMovieById(int ID);
    Task<List<Movie>> GetMovieList();
}
