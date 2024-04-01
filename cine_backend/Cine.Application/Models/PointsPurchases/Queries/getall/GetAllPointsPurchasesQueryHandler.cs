using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.PointsPurchases;

public class GetAllPointsPurchasesQueryHandler : IRequestHandler<GetAllPointsPurchasesQuery, ErrorOr<GetAllPointsPurchasesResult>>
{
    private readonly IPointsPurchaseRepository _pointsPurchaseRepository;
    public GetAllPointsPurchasesQueryHandler(IPointsPurchaseRepository pointsPurchaseRepository)
    {
        _pointsPurchaseRepository = pointsPurchaseRepository;
    }
    public async Task<ErrorOr<GetAllPointsPurchasesResult>> Handle(GetAllPointsPurchasesQuery request, CancellationToken cancellationToken)
    {
        List<PointsPurchase> PointsPurchases = await _pointsPurchaseRepository.GetPointsPurchaseList();
        return new GetAllPointsPurchasesResult(PointsPurchases);
    }
}