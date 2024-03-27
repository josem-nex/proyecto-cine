using ErrorOr;
using MediatR;

namespace Cine.Application.Models.ShowTimes;

public record AddShowTimeCommand(int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId) : IRequest<ErrorOr<GetShowTimeResult>>;
