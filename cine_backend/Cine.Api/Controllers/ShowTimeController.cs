using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using MapsterMapper;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Entities.Movies;
namespace Cine.Api.Controllers
{
    [Route("ShowTimes")]
    public class ShowTimeController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public ShowTimeController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllShowTimes()
        {
            var query = new GetAllShowTimesQuery();
            ErrorOr<GetAllShowTimesResult> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(_mapper.Map<GetAllShowTimesResult>(result)),
                errors => Problem(errors)
            );
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddShowTime(AddShowTimeRequest request)
        {
            var command = _mapper.Map<AddShowTimeCommand>(request);
            ErrorOr<GetShowTimeResult> ShowTimeResult = await _mediator.Send(command);
            return ShowTimeResult.Match(
                ShowTimeResult => Ok(_mapper.Map<GetShowTimeResponse>(ShowTimeResult)),
                errors => Problem(errors)
            );
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetShowTime(GetShowTimeRequest request)
        {
            var query = _mapper.Map<GetShowTimeQuery>(request);
            ErrorOr<GetShowTimeResult> authResult = await _mediator.Send(query);
            return authResult.Match(
                authResult => Ok(_mapper.Map<GetShowTimeResponse>(authResult)),
                errors => Problem(errors)
            );
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteShowTime(DeleteShowTimeRequest request)
        {
            var command = _mapper.Map<DeleteShowTimeCommand>(request);
            ErrorOr<Unit> result = await _mediator.Send(command);
            return result.Match(
                _ => Ok(),
                errors => Problem(errors)
            );
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateShowTime(UpdateShowTimeRequest request)
        {
            var command = _mapper.Map<UpdateShowTimeCommand>(request);
            ErrorOr<GetShowTimeResult> result = await _mediator.Send(command);
            return result.Match(
                result => Ok(_mapper.Map<GetShowTimeResponse>(result)),
                errors => Problem(errors)
            );
        }
    }

    public record UpdateShowTimeCommand(int Id, int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId) : IRequest<ErrorOr<GetShowTimeResult>>;

    public record UpdateShowTimeRequest(int Id, int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId);

    public record DeleteShowTimeCommand(int Id) : IRequest<ErrorOr<Unit>>;
    public record DeleteShowTimeRequest(int Id);

    public record GetShowTimeQuery(int Id) : IRequest<ErrorOr<GetShowTimeResult>>;

    public record GetShowTimeRequest(int Id);

    public record GetShowTimeResponse(int Id, Hall Halls, int HallsId, Schedule Schedules, int SchedulesId, int Cost, int CostPoints, Movie Movie, int MovieId);

    public record GetShowTimeResult(ShowTime ShowTime);

    public record AddShowTimeCommand(int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId) : IRequest<ErrorOr<GetShowTimeResult>>;

    public record AddShowTimeRequest(int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId);

    public record GetAllShowTimesResult(List<ShowTime> ShowTimes);

    public record GetAllShowTimesQuery() : IRequest<ErrorOr<GetAllShowTimesResult>>;
}