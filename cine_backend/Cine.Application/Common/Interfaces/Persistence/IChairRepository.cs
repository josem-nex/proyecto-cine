using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Common.Interfaces.Persistence;
public interface IChairRepository
{
    Task<Chair?> GetChairById(int Id);
    Task<List<Chair>> GetChairList();
}