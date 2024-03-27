using ErrorOr;
using MediatR;

namespace Cine.Application.Models.ShowTimes;

public record UpdateShowTimeCommand(int Id, int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId) : IRequest<ErrorOr<GetShowTimeResult>>;
