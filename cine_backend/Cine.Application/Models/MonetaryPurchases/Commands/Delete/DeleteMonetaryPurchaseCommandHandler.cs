using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.MonetaryPurchases.Commands;

public class DeleteMonetaryPurchaseCommandHandler : IRequestHandler<DeleteMonetaryPurchaseCommand, ErrorOr<Unit>>
{
    private readonly IMonetaryPurchaseRepository _monetaryPurchaseRepository;
    public DeleteMonetaryPurchaseCommandHandler(IMonetaryPurchaseRepository monetaryPurchaseRepository)
    {
        _monetaryPurchaseRepository = monetaryPurchaseRepository;
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteMonetaryPurchaseCommand request, CancellationToken cancellationToken)
    {
        var monetaryPurchase = await _monetaryPurchaseRepository.GetMonetaryPurchaseById(request.TicketId);
        if (monetaryPurchase is null)
        {
            return Errors.Tickets.TicketNotFound;
        }
        await _monetaryPurchaseRepository.Delete(monetaryPurchase);
        return Unit.Value;
    }
}
