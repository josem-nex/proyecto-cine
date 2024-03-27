using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using MapsterMapper;
using Cine.Domain.Entities.Tickets;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Application.Models.Schedules.Commands;
using Cine.Application.Models.Schedules.Queries.Get;
using Cine.Application.Models.Schedules.Queries.GetAll;
namespace Cine.Api.Controllers
{
    [Route("schedules")]
    public class ScheduleController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public ScheduleController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllSchedules()
        {
            var query = new GetAllSchedulesQuery();
            ErrorOr<GetAllSchedulesResult> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(_mapper.Map<GetAllSchedulesResult>(result)),
                errors => Problem(errors)
            );
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddSchedule(AddScheduleRequest request)
        {
            var command = _mapper.Map<AddScheduleCommand>(request);
            ErrorOr<GetScheduleResult> ScheduleResult = await _mediator.Send(command);
            return ScheduleResult.Match(
                ScheduleResult => Ok(_mapper.Map<GetScheduleResponse>(ScheduleResult)),
                errors => Problem(errors)
            );
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetSchedule(GetScheduleRequest request)
        {
            var query = _mapper.Map<GetScheduleQuery>(request);
            ErrorOr<GetScheduleResult> authResult = await _mediator.Send(query);
            return authResult.Match(
                authResult => Ok(_mapper.Map<GetScheduleResponse>(authResult)),
                errors => Problem(errors)
            );
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteSchedule(DeleteScheduleRequest request)
        {
            var command = _mapper.Map<DeleteScheduleCommand>(request);
            ErrorOr<Unit> result = await _mediator.Send(command);
            return result.Match(
                _ => Ok(),
                errors => Problem(errors)
            );
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateSchedule(UpdateScheduleRequest request)
        {
            var command = _mapper.Map<UpdateScheduleCommand>(request);
            ErrorOr<GetScheduleResult> result = await _mediator.Send(command);
            return result.Match(
                result => Ok(_mapper.Map<GetScheduleResponse>(result)),
                errors => Problem(errors)
            );
        }
    }
}