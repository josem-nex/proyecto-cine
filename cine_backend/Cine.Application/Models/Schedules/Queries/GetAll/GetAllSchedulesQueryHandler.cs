using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
namespace Cine.Application.Models.Schedules.Queries.GetAll;

public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedulesQuery, ErrorOr<GetAllSchedulesResult>>
{
    private readonly IScheduleRepository _schedules;
    public GetAllSchedulesQueryHandler(IScheduleRepository schedules)
    {
        _schedules = schedules;
    }
    public async Task<ErrorOr<GetAllSchedulesResult>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken)
    {
        var Schedules = await _schedules.GetScheduleList();
        return new GetAllSchedulesResult(Schedules);
    }
}