using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Entities.Movies;
using Cine.Domain.Common.Errors;
using MediatR;

namespace Cine.Application.Models.ShowTimes;

public class AddShowTimeCommandHandler : IRequestHandler<AddShowTimeCommand, ErrorOr<GetShowTimeResult>>
{
    private readonly IShowTimeRepository _ShowTimeRepository;
    private readonly IHallRepository _HallRepository;
    private readonly IScheduleRepository _ScheduleRepository;
    private readonly IMovieRepository _MovieRepository;
    public AddShowTimeCommandHandler(IShowTimeRepository ShowTimeRepository, IHallRepository HallRepository, IScheduleRepository ScheduleRepository, IMovieRepository MovieRepository)
    {
        _ShowTimeRepository = ShowTimeRepository;
        _HallRepository = HallRepository;
        _ScheduleRepository = ScheduleRepository;
        _MovieRepository = MovieRepository;
    }
    public async Task<ErrorOr<GetShowTimeResult>> Handle(AddShowTimeCommand request, CancellationToken cancellationToken)
    {
        Hall? Halls = await _HallRepository.GetHallById(request.HallsId);
        if (Halls is null)
        {
            return Errors.Hall.HallNotFound;
        }

        Schedule? Schedules = await _ScheduleRepository.GetScheduleById(request.SchedulesId);
        if (Schedules is null)
        {
            return Errors.Schedule.ScheduleNotFound;
        }
        Movie? Movie = await _MovieRepository.GetMovieById(request.MovieId);
        if (Movie is null)
        {
            return Errors.Movie.MovieNotFound;
        }
        ShowTime ShowTime = new ShowTime(request.HallsId, request.SchedulesId, request.Cost, request.CostPoints, request.MovieId);
        await _ShowTimeRepository.Add(ShowTime);
        return new GetShowTimeResult(ShowTime);
    }
}
