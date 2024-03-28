using Cine.Domain.Entities.Movies;

namespace Cine.Application.Common.Interfaces.Persistence;
public interface IActorRepository
{
    Task<Actor?> GetActorById(int Id);
    Task<List<Actor>> GetActorList();
}