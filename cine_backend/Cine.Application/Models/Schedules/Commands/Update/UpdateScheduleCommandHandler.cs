using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Cine.Application.Models.Schedules.Queries.Get;

namespace Cine.Application.Models.Schedules.Commands;

public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, ErrorOr<GetScheduleResult>>
{
    private readonly IScheduleRepository _schedules;
    public UpdateScheduleCommandHandler(IScheduleRepository schedules)
    {
        _schedules = schedules;
    }
    public async Task<ErrorOr<GetScheduleResult>> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
    {
        var Schedule = await _schedules.GetScheduleById(request.Id);
        if (Schedule == null)
        {
            return Errors.Schedule.ScheduleNotFound;
        }
        Schedule.Update(request.DateStart, request.DateEnd);
        await _schedules.Update(Schedule);
        return new GetScheduleResult(Schedule);
    }
}
