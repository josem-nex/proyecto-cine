using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using MapsterMapper;
using Cine.Application.Models.ShowTimes;
namespace Cine.Api.Controllers
{
    [Route("showtimes")]
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
}