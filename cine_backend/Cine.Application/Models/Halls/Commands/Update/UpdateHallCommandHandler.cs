using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Cine.Application.Models.Halls.Queries;

namespace Cine.Application.Models.Halls.Commands;

public class UpdateHallCommandHandler : IRequestHandler<UpdateHallCommand, ErrorOr<GetHallResult>>
{
    private readonly IHallRepository _repository;
    private readonly IScheduleRepository _scheduleRepository;
    public UpdateHallCommandHandler(IHallRepository repository, IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
        _repository = repository;
    }
    public async Task<ErrorOr<GetHallResult>> Handle(UpdateHallCommand request, CancellationToken cancellationToken)
    {
        var hall = await _repository.GetHallById(request.Id);
        if (hall == null)
        {
            return Errors.Hall.HallNotFound;
        }
        foreach (var scheduleId in request.SchedulesId)
        {
            var schedule = await _scheduleRepository.GetScheduleById(scheduleId);
            if (schedule is null)
            {
                return Errors.Schedule.ScheduleNotFound;
            }
        }
        hall.Update(request.Name, request.Capacity);
        await _repository.Update(hall, request.SchedulesId);
        return new GetHallResult(hall);
    }
}
