using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Schedules.Commands;

public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, ErrorOr<Unit>>
{
    private readonly IScheduleRepository _schedules;
    public DeleteScheduleCommandHandler(IScheduleRepository schedules)
    {
        _schedules = schedules;
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
    {
        var Schedule = await _schedules.GetScheduleById(request.Id);
        if (Schedule == null)
        {
            return Errors.Schedule.ScheduleNotFound;
        }
        await _schedules.Delete(Schedule);
        return Unit.Value;
    }
}
