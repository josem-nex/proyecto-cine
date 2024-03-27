using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Common.Interfaces.Persistence;
public interface IScheduleRepository
{
    Task Add(Schedule Schedule);
    Task<Schedule?> GetScheduleById(int Id);
    Task Delete(Schedule Schedule);
    Task<List<Schedule>> GetScheduleList();
    Task<Schedule?> Update(Schedule Schedule);
}