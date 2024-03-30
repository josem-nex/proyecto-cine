using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cine.Application.Models.Discounts;

namespace Cine.Api.Controllers;

[Route("discounts")]
public class DiscountController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public DiscountController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllDiscounts()
    {
        var query = new GetAllDiscountsQuery();
        ErrorOr<GetAllDiscountsResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<GetAllDiscountsResult>(result)),
            errors => Problem(errors)
        );
    }
    [HttpPost("get")]
    public async Task<IActionResult> GetDiscount(GetDiscountRequest request)
    {
        var query = _mapper.Map<GetDiscountQuery>(request);
        ErrorOr<GetDiscountResult> DiscountResult = await _mediator.Send(query);
        return DiscountResult.Match(
            DiscountResult => Ok(_mapper.Map<GetDiscountResponse>(DiscountResult)),
            errors => Problem(errors)
        );
    }
}
