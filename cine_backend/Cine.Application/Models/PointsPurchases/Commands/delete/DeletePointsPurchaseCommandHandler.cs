using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;
namespace Cine.Application.Models.PointsPurchases.Commands;
public class DeletePointsPurchaseCommandHandler : IRequestHandler<DeletePointsPurchaseCommand, ErrorOr<Unit>>
{
    private readonly IPointsPurchaseRepository _pointsPurchaseRepository;
    public DeletePointsPurchaseCommandHandler(IPointsPurchaseRepository pointsPurchaseRepository)
    {
        _pointsPurchaseRepository = pointsPurchaseRepository;
    }
    public async Task<ErrorOr<Unit>> Handle(DeletePointsPurchaseCommand request, CancellationToken cancellationToken)
    {
        var PointsPurchase = await _pointsPurchaseRepository.GetPointsPurchaseById(request.TicketId);
        if (PointsPurchase is null)
        {
            return Errors.Tickets.PurchaseNotFound;
        }
        await _pointsPurchaseRepository.Delete(PointsPurchase);
        return Unit.Value;
    }
}
