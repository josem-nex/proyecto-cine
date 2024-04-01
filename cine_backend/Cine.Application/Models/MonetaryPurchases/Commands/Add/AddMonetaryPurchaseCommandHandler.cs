using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Models.MonetaryPurchases.Queries;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.MonetaryPurchases.Commands;

public class AddMonetaryPurchaseCommandHandler : IRequestHandler<AddMonetaryPurchaseCommand, ErrorOr<GetMonetaryPurchaseResult>>
{
    private readonly IMonetaryPurchaseRepository _monetaryPurchaseRepository;
    private readonly IPartnerRepository _partnerRepository;
    private readonly ITicketRepository _ticketRepository;
    public AddMonetaryPurchaseCommandHandler(IMonetaryPurchaseRepository monetaryPurchaseRepository, ITicketRepository ticketRepository, IPartnerRepository partnerRepository)
    {
        _monetaryPurchaseRepository = monetaryPurchaseRepository;
        _ticketRepository = ticketRepository;
        _partnerRepository = partnerRepository;
    }
    public async Task<ErrorOr<GetMonetaryPurchaseResult>> Handle(AddMonetaryPurchaseCommand request, CancellationToken cancellationToken)
    {
        var monetaryPurchase = await _monetaryPurchaseRepository.GetMonetaryPurchaseById(request.TicketId);
        if (monetaryPurchase is not null)
        {
            return Errors.Tickets.PurchaseAlreadyExists;
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
        var monetaryPurchaseNew = new MonetaryPurchase(request.UserId, request.TicketId, request.TotalPrice, request.CreditCard);
        await _monetaryPurchaseRepository.Add(monetaryPurchaseNew);
        return new GetMonetaryPurchaseResult(monetaryPurchaseNew);
    }
}
