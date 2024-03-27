using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;
namespace Cine.Application.Models.Schedules.Queries.Get;
public class GetScheduleQueryHandler : IRequestHandler<GetScheduleQuery, ErrorOr<GetScheduleResult>>
{
    private readonly IScheduleRepository _schedules;
    public GetScheduleQueryHandler(IScheduleRepository schedules)
    {
        _schedules = schedules;
    }
    public async Task<ErrorOr<GetScheduleResult>> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
    {
        var Schedule = await _schedules.GetScheduleById(request.Id);
        if (Schedule == null)
        {
            return Errors.Schedule.ScheduleNotFound;
        }
        return new GetScheduleResult(Schedule);
    }
}
