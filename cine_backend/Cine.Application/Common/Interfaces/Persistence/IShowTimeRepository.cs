using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Common.Interfaces.Persistence;
public interface IShowTimeRepository
{
    Task Add(ShowTime ShowTime);
    Task<ShowTime?> GetShowTimeById(int Id);
    Task Delete(ShowTime ShowTime);
    Task<List<ShowTime>> GetShowTimeList();
    Task<ShowTime?> Update(ShowTime ShowTime);
}