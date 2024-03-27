using Cine.Domain.Entities.Tickets;
namespace Cine.Application.Models.Schedules.Queries.GetAll;

public record GetAllSchedulesResult(List<Schedule> Schedules);
