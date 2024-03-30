using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Discounts;

public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, ErrorOr<GetDiscountResult>>
{
    private readonly IDiscountRepository _discountRepository;
    public GetDiscountQueryHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    public async Task<ErrorOr<GetDiscountResult>> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var Discount = await _discountRepository.GetDiscountById(request.Id);
        if (Discount is null)
        {
            return Errors.Tickets.DiscountNotFound;
        }
        return new GetDiscountResult(Discount);
    }
}
