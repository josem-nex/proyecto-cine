using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Models.PointsPurchases;
using Cine.Application.Models.PointsPurchases.Commands;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities.Tickets;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Api.Controllers;
[Route("pointspurchase")]
public class PointsPurchaseController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public PointsPurchaseController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAllPointsPurchases()
    {
        var query = new GetAllPointsPurchasesQuery();
        ErrorOr<GetAllPointsPurchasesResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<GetAllPointsPurchasesResult>(result)),
            errors => Problem(errors)
        );
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddPointsPurchase(AddPointsPurchaseRequest request)
    {
        var command = _mapper.Map<AddPointsPurchaseCommand>(request);
        ErrorOr<GetPointsPurchaseResult> PointsPurchaseResult = await _mediator.Send(command);
        return PointsPurchaseResult.Match(
            PointsPurchaseResult => Ok(_mapper.Map<GetPointsPurchaseResponse>(PointsPurchaseResult)),
            errors => Problem(errors)
        );
    }
    [HttpPost("get")]
    public async Task<IActionResult> GetPointsPurchase(GetPointsPurchaseRequest request)
    {
        var query = _mapper.Map<GetPointsPurchaseQuery>(request);
        ErrorOr<GetPointsPurchaseResult> authResult = await _mediator.Send(query);
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetPointsPurchaseResponse>(authResult)),
            errors => Problem(errors)
        );
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeletePointsPurchase(DeletePointsPurchaseRequest request)
    {
        var command = _mapper.Map<DeletePointsPurchaseCommand>(request);
        ErrorOr<Unit> result = await _mediator.Send(command);
        return result.Match(
            _ => Ok(),
            errors => Problem(errors)
        );
    }
    [HttpPost("update")]
    public async Task<IActionResult> UpdatePointsPurchase(UpdatePointsPurchaseRequest request)
    {
        var command = _mapper.Map<UpdatePointsPurchaseCommand>(request);
        ErrorOr<GetPointsPurchaseResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<GetPointsPurchaseResponse>(result)),
            errors => Problem(errors)
        );
    }
}
