using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using MapsterMapper;
using Cine.Application.Models.Halls.Queries;
using Cine.Application.Models.Halls.Commands;
using Cine.Application.Models.Halls.Queries.GetChairs;
namespace Cine.Api.Controllers
{
    [Route("halls")]
    public class HallController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public HallController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllHalls()
        {
            var query = new GetAllHallsQuery();
            ErrorOr<GetAllHallsResult> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(_mapper.Map<GetAllHallsResult>(result)),
                errors => Problem(errors)
            );
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddHall(AddHallRequest request)
        {
            var command = _mapper.Map<AddHallCommand>(request);
            ErrorOr<AddHallResult> HallResult = await _mediator.Send(command);
            return HallResult.Match(
                HallResult => Ok(_mapper.Map<AddHallResponse>(HallResult)),
                errors => Problem(errors)
            );
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetHall(GetHallRequest request)
        {
            var query = _mapper.Map<GetHallQuery>(request);
            ErrorOr<GetHallResult> authResult = await _mediator.Send(query);
            return authResult.Match(
                authResult => Ok(_mapper.Map<GetHallResponse>(authResult)),
                errors => Problem(errors)
            );
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteHall(DeleteHallRequest request)
        {
            var command = _mapper.Map<DeleteHallCommand>(request);
            ErrorOr<Unit> result = await _mediator.Send(command);
            return result.Match(
                _ => Ok(),
                errors => Problem(errors)
            );
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateHall(UpdateHallRequest request)
        {
            var command = _mapper.Map<UpdateHallCommand>(request);
            ErrorOr<GetHallResult> result = await _mediator.Send(command);
            return result.Match(
                result => Ok(_mapper.Map<GetHallResponse>(result)),
                errors => Problem(errors)
            );
        }
        [HttpPost("getchairshall")]
        public async Task<IActionResult> GetChairs(GetChairsHallRequest request)
        {
            var query = _mapper.Map<GetChairsHallQuery>(request);
            ErrorOr<GetChairsHallResult> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(_mapper.Map<GetChairsHallResult>(result)),
                errors => Problem(errors)
            );
        }
    }

}