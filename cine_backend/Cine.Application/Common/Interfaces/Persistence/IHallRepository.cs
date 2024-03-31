using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Common.Interfaces.Persistence;
public interface IHallRepository
{
    Task Add(Hall Hall, List<int> SchedulesId);
    Task<Hall?> GetHallById(int Id);
    Task<Hall?> GetHallByName(string Name);
    Task Delete(Hall Hall);
    Task<List<Hall>> GetHallList();
    Task<Hall?> Update(Hall Hall, List<int> SchedulesId);
    Task<List<int>> GetChairsId(int Id);
}