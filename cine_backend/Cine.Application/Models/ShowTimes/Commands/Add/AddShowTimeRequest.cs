namespace Cine.Application.Models.ShowTimes;

public record AddShowTimeRequest(int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId);
