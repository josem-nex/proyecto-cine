using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Discounts;

public class GetAllDiscountsQueryHandler : IRequestHandler<GetAllDiscountsQuery, ErrorOr<GetAllDiscountsResult>>
{
    private readonly IDiscountRepository _discountRepository;
    public GetAllDiscountsQueryHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    public async Task<ErrorOr<GetAllDiscountsResult>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
    {
        var Discounts = await _discountRepository.GetDiscountList();
        return new GetAllDiscountsResult(Discounts);
    }
}