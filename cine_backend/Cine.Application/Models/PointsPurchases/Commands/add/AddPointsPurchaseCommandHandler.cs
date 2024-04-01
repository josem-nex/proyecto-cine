using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities.Tickets;
using ErrorOr;
using MediatR;
namespace Cine.Application.Models.PointsPurchases.Commands;

public class AddPointsPurchaseCommandHandler : IRequestHandler<AddPointsPurchaseCommand, ErrorOr<GetPointsPurchaseResult>>
{
    private readonly IPointsPurchaseRepository _pointsPurchaseRepository;
    private readonly IPartnerRepository _partnerRepository;
    private readonly ITicketRepository _ticketRepository;
    public AddPointsPurchaseCommandHandler(IPointsPurchaseRepository pointsPurchaseRepository, IPartnerRepository partnerRepository, ITicketRepository ticketRepository)
    {
        _pointsPurchaseRepository = pointsPurchaseRepository;
        _partnerRepository = partnerRepository;
        _ticketRepository = ticketRepository;
    }
    public async Task<ErrorOr<GetPointsPurchaseResult>> Handle(AddPointsPurchaseCommand request, CancellationToken cancellationToken)
    {
        var pointspurchase = await _pointsPurchaseRepository.GetPointsPurchaseById(request.TicketId);
        if (pointspurchase is not null)
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
        PointsPurchase PointsPurchase = new PointsPurchase(partner, ticket, request.TotalPoints);
        await _pointsPurchaseRepository.Add(PointsPurchase);
        return new GetPointsPurchaseResult(PointsPurchase);
    }
}
