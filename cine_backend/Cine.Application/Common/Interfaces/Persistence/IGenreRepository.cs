using Cine.Domain.Entities.Movies;

namespace Cine.Application.Common.Interfaces.Persistence;
public interface IGenreRepository
{
    Task<Genre?> GetGenreById(int Id);
    Task<List<Genre>> GetGenreList();
}