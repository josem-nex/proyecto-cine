using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cine.Application.Models.Tickets.Queries;
using Cine.Application.Models.Tickets.Commands;

namespace Cine.Api.Controllers;
[Route("tickets")]
public class TicketController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public TicketController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAllTickets()
    {
        var query = new GetAllTicketsQuery();
        ErrorOr<GetAllTicketsResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<GetAllTicketsResult>(result)),
            errors => Problem(errors)
        );
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddTicket(AddTicketRequest request)
    {
        var command = _mapper.Map<AddTicketCommand>(request);
        ErrorOr<GetTicketResult> TicketResult = await _mediator.Send(command);
        return TicketResult.Match(
            TicketResult => Ok(_mapper.Map<GetTicketResponse>(TicketResult)),
            errors => Problem(errors)
        );
    }
    [HttpPost("get")]
    public async Task<IActionResult> GetTicket(GetTicketRequest request)
    {
        var query = _mapper.Map<GetTicketQuery>(request);
        ErrorOr<GetTicketResult> authResult = await _mediator.Send(query);
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetTicketResponse>(authResult)),
            errors => Problem(errors)
        );
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteTicket(DeleteTicketRequest request)
    {
        var command = _mapper.Map<DeleteTicketCommand>(request);
        ErrorOr<Unit> result = await _mediator.Send(command);
        return result.Match(
            _ => Ok(),
            errors => Problem(errors)
        );
    }
    [HttpPost("update")]
    public async Task<IActionResult> UpdateTicket(UpdateTicketRequest request)
    {
        var command = _mapper.Map<UpdateTicketCommand>(request);
        ErrorOr<GetTicketResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<GetTicketResponse>(result)),
            errors => Problem(errors)
        );
    }
}
