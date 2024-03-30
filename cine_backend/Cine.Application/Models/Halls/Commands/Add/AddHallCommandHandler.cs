using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Commands;

public class AddHallCommandHandler : IRequestHandler<AddHallCommand, ErrorOr<AddHallResult>>
{
    private readonly IHallRepository _repository;
    private readonly IScheduleRepository _scheduleRepository;
    public AddHallCommandHandler(IHallRepository repository, IScheduleRepository scheduleRepository)
    {
        _repository = repository;
        _scheduleRepository = scheduleRepository;
    }
    public async Task<ErrorOr<AddHallResult>> Handle(AddHallCommand request, CancellationToken cancellationToken)
    {
        var halltest = await _repository.GetHallByName(request.Name);
        if (halltest != null)
        {
            return Errors.Hall.DuplicatedHall;
        }
        foreach (var scheduleId in request.SchedulesId)
        {
            var schedule = await _scheduleRepository.GetScheduleById(scheduleId);
            if (schedule is null)
            {
                return Errors.Schedule.ScheduleNotFound;
            }
        }
        var hall = new Hall(request.Name, request.Capacity);
        await _repository.Add(hall, request.SchedulesId);
        return new AddHallResult(hall);
    }
}
