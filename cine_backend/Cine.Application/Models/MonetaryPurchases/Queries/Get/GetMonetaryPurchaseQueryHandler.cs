using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Common.Errors;

namespace Cine.Application.Models.MonetaryPurchases.Queries;

public class GetMonetaryPurchaseQueryHandler : IRequestHandler<GetMonetaryPurchaseQuery, ErrorOr<GetMonetaryPurchaseResult>>
{
    private readonly IMonetaryPurchaseRepository _monetaryPurchaseRepository;
    public GetMonetaryPurchaseQueryHandler(IMonetaryPurchaseRepository monetaryPurchaseRepository)
    {
        _monetaryPurchaseRepository = monetaryPurchaseRepository;
    }
    public async Task<ErrorOr<GetMonetaryPurchaseResult>> Handle(GetMonetaryPurchaseQuery request, CancellationToken cancellationToken)
    {
        var monetaryPurchase = await _monetaryPurchaseRepository.GetMonetaryPurchaseById(request.TicketId);
        if (monetaryPurchase is null)
        {
            return Errors.Tickets.TicketNotFound;
        }
        return new GetMonetaryPurchaseResult(monetaryPurchase);
    }
}
