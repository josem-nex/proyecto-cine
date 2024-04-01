using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.MonetaryPurchases.Queries;

public class GetAllMonetaryPurchasesQueryHandler : IRequestHandler<GetAllMonetaryPurchasesQuery, ErrorOr<GetAllMonetaryPurchasesResult>>
{
    private readonly IMonetaryPurchaseRepository _monetaryPurchaseRepository;
    public GetAllMonetaryPurchasesQueryHandler(IMonetaryPurchaseRepository monetaryPurchaseRepository)
    {
        _monetaryPurchaseRepository = monetaryPurchaseRepository;
    }
    public async Task<ErrorOr<GetAllMonetaryPurchasesResult>> Handle(GetAllMonetaryPurchasesQuery request, CancellationToken cancellationToken)
    {
        var monetaryPurchases = await _monetaryPurchaseRepository.GetMonetaryPurchaseList();
        return new GetAllMonetaryPurchasesResult(monetaryPurchases);
    }
}