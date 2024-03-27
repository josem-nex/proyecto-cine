using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Cine.Application.Models.Schedules.Queries.Get;

namespace Cine.Application.Models.Schedules.Commands;

public class AddScheduleCommandHandler : IRequestHandler<AddScheduleCommand, ErrorOr<GetScheduleResult>>
{
    private readonly IScheduleRepository _schedules;
    public AddScheduleCommandHandler(IScheduleRepository schedules)
    {
        _schedules = schedules;
    }
    public async Task<ErrorOr<GetScheduleResult>> Handle(AddScheduleCommand request, CancellationToken cancellationToken)
    {
        if (request.DateEnd < request.DateStart)
        {
            return Errors.Schedule.ScheduleInvalid;
        }
        var Schedule = new Schedule(request.DateStart, request.DateEnd);
        await _schedules.Add(Schedule);
        return new GetScheduleResult(Schedule);
    }
}
