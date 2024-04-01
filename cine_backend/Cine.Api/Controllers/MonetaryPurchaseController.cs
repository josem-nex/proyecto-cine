/* using Cine.Domain.Entities.Tickets;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Api.Controllers;
[Route("monetarypurchase")]
public class MonetaryPurchaseController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public MonetaryPurchaseController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAllMonetaryPurchases()
    {
        var query = new GetAllMonetaryPurchasesQuery();
        ErrorOr<GetAllMonetaryPurchasesResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<GetAllMonetaryPurchasesResult>(result)),
            errors => Problem(errors)
        );
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddMonetaryPurchase(AddMonetaryPurchaseRequest request)
    {
        var command = _mapper.Map<AddMonetaryPurchaseCommand>(request);
        ErrorOr<GetMonetaryPurchaseResult> MonetaryPurchaseResult = await _mediator.Send(command);
        return MonetaryPurchaseResult.Match(
            MonetaryPurchaseResult => Ok(_mapper.Map<GetMonetaryPurchaseResponse>(MonetaryPurchaseResult)),
            errors => Problem(errors)
        );
    }
    [HttpPost("get")]
    public async Task<IActionResult> GetMonetaryPurchase(GetMonetaryPurchaseRequest request)
    {
        var query = _mapper.Map<GetMonetaryPurchaseQuery>(request);
        ErrorOr<GetMonetaryPurchaseResult> authResult = await _mediator.Send(query);
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetMonetaryPurchaseResponse>(authResult)),
            errors => Problem(errors)
        );
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteMonetaryPurchase(DeleteMonetaryPurchaseRequest request)
    {
        var command = _mapper.Map<DeleteMonetaryPurchaseCommand>(request);
        ErrorOr<Unit> result = await _mediator.Send(command);
        return result.Match(
            _ => Ok(),
            errors => Problem(errors)
        );
    }
    [HttpPost("update")]
    public async Task<IActionResult> UpdateMonetaryPurchase(UpdateMonetaryPurchaseRequest request)
    {
        var command = _mapper.Map<UpdateMonetaryPurchaseCommand>(request);
        ErrorOr<GetMonetaryPurchaseResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<GetMonetaryPurchaseResponse>(result)),
            errors => Problem(errors)
        );
    }
}

public record UpdateMonetaryPurchaseCommand(Guid UserId, int TicketsId, int TotalPrice, string CreditCard) : IRequest<ErrorOr<GetMonetaryPurchaseResult>>;

public record UpdateMonetaryPurchaseRequest(Guid UserId, int TicketsId, int TotalPrice, string CreditCard);

public record DeleteMonetaryPurchaseCommand(int TicketId) : IRequest<ErrorOr<Unit>>;

public record DeleteMonetaryPurchaseRequest(int TicketId);

public record GetMonetaryPurchaseRequest(int TicketId);
public record GetMonetaryPurchaseResult(MonetaryPurchase MonetaryPurchase);
public record GetMonetaryPurchaseResponse(Guid UserId, int TicketsId, int TotalPrice, string CreditCard);
public record GetMonetaryPurchaseQuery(int TicketId) : IRequest<ErrorOr<GetMonetaryPurchaseResult>>;
public record AddMonetaryPurchaseCommand(Guid UserId, int TicketsId, int TotalPrice, string CreditCard) : IRequest<ErrorOr<GetMonetaryPurchaseResult>>;

public record AddMonetaryPurchaseRequest(Guid UserId, int TicketsId, int TotalPrice, string CreditCard);

public record GetAllMonetaryPurchasesResult(List<MonetaryPurchase> MonetaryPurchases);

public record GetAllMonetaryPurchasesQuery() : IRequest<ErrorOr<GetAllMonetaryPurchasesResult>>; */