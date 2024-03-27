namespace Cine.Application.Models.Schedules.Commands;

public record UpdateScheduleRequest(int Id, DateTime DateStart, DateTime DateEnd);
