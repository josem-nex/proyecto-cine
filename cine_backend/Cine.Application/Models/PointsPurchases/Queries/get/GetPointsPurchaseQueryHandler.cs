using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.PointsPurchases;

public class GetPointsPurchaseQueryHandler : IRequestHandler<GetPointsPurchaseQuery, ErrorOr<GetPointsPurchaseResult>>
{
    private readonly IPointsPurchaseRepository _pointsPurchaseRepository;
    public GetPointsPurchaseQueryHandler(IPointsPurchaseRepository pointsPurchaseRepository)
    {
        _pointsPurchaseRepository = pointsPurchaseRepository;
    }
    public async Task<ErrorOr<GetPointsPurchaseResult>> Handle(GetPointsPurchaseQuery request, CancellationToken cancellationToken)
    {
        var PointsPurchase = await _pointsPurchaseRepository.GetPointsPurchaseById(request.TicketId);
        if (PointsPurchase is null)
        {
            return Errors.Tickets.PurchaseNotFound;
        }
        return new GetPointsPurchaseResult(PointsPurchase);
    }
}
