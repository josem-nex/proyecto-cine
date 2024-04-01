using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Models.MonetaryPurchases.Queries;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.MonetaryPurchases.Commands;

public class UpdateMonetaryPurchaseCommandHandler : IRequestHandler<UpdateMonetaryPurchaseCommand, ErrorOr<GetMonetaryPurchaseResult>>
{
    private readonly IMonetaryPurchaseRepository _monetaryPurchaseRepository;
    private readonly IPartnerRepository _partnerRepository;
    private readonly ITicketRepository _ticketRepository;
    public UpdateMonetaryPurchaseCommandHandler(IMonetaryPurchaseRepository monetaryPurchaseRepository, ITicketRepository ticketRepository, IPartnerRepository partnerRepository)
    {
        _monetaryPurchaseRepository = monetaryPurchaseRepository;
        _ticketRepository = ticketRepository;
        _partnerRepository = partnerRepository;
    }
    public async Task<ErrorOr<GetMonetaryPurchaseResult>> Handle(UpdateMonetaryPurchaseCommand request, CancellationToken cancellationToken)
    {
        var monetaryPurchase = await _monetaryPurchaseRepository.GetMonetaryPurchaseById(request.TicketId);
        if (monetaryPurchase is null)
        {
            return Errors.Tickets.TicketNotFound;
        }
        var partner = await _partnerRepository.GetPartnerById(request.UserId);
        if (partner is null)
        {
            return Errors.Partner.PartnerNotFound;
        }
        var ticket = await _ticketRepository.GetTicketById(request.TicketId);
        if (ticket is null)
        {
            return Errors.Tickets.TicketNotFound;
        }
        monetaryPurchase.Update(request.UserId, request.TicketId, request.TotalPrice, request.CreditCard);
        await _monetaryPurchaseRepository.Update(monetaryPurchase);
        return new GetMonetaryPurchaseResult(monetaryPurchase);
    }
}
