namespace Cine.Application.Models.ShowTimes;

public record GetShowTimeResponse(int Id, int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId);
