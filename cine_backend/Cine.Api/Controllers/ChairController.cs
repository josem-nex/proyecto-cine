using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cine.Application.Models.Chairs;

namespace Cine.Api.Controllers;

[Route("chairs")]
public class ChairController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public ChairController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllChairs()
    {
        var query = new GetAllChairsQuery();
        ErrorOr<GetAllChairsResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<GetAllChairsResult>(result)),
            errors => Problem(errors)
        );
    }
    [HttpPost("get")]
    public async Task<IActionResult> GetChair(GetChairRequest request)
    {
        var query = _mapper.Map<GetChairQuery>(request);
        ErrorOr<GetChairResult> ChairResult = await _mediator.Send(query);
        return ChairResult.Match(
            ChairResult => Ok(_mapper.Map<GetChairResponse>(ChairResult)),
            errors => Problem(errors)
        );
    }
}
