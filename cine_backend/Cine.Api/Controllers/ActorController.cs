using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cine.Application.Models.Actors;

namespace Cine.Api.Controllers;

[Route("actors")]
public class ActorController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public ActorController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllActors()
    {
        var query = new GetAllActorsQuery();
        ErrorOr<GetAllActorsResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<GetAllActorsResult>(result)),
            errors => Problem(errors)
        );
    }
    [HttpPost("get")]
    public async Task<IActionResult> GetActor(GetActorRequest request)
    {
        var query = _mapper.Map<GetActorQuery>(request);
        ErrorOr<GetActorResult> ActorResult = await _mediator.Send(query);
        return ActorResult.Match(
            ActorResult => Ok(_mapper.Map<GetActorResponse>(ActorResult)),
            errors => Problem(errors)
        );
    }
}
