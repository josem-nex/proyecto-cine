namespace Cine.Application.Models.Halls.Commands;
public record UpdateHallRequest(int Id, string Name, int Capacity, List<int> SchedulesId);
