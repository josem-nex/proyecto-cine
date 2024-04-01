using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;
namespace Cine.Application.Models.PointsPurchases.Commands;


public class UpdatePointsPurchaseCommandHandler : IRequestHandler<UpdatePointsPurchaseCommand, ErrorOr<GetPointsPurchaseResult>>
{
    private readonly IPointsPurchaseRepository _pointsPurchaseRepository;
    private readonly IPartnerRepository _partnerRepository;
    private readonly ITicketRepository _ticketRepository;
    public UpdatePointsPurchaseCommandHandler(IPointsPurchaseRepository pointsPurchaseRepository, IPartnerRepository partnerRepository, ITicketRepository ticketRepository)
    {
        _pointsPurchaseRepository = pointsPurchaseRepository;
        _partnerRepository = partnerRepository;
        _ticketRepository = ticketRepository;
    }
    public async Task<ErrorOr<GetPointsPurchaseResult>> Handle(UpdatePointsPurchaseCommand request, CancellationToken cancellationToken)
    {
        var pointspurchase = await _pointsPurchaseRepository.GetPointsPurchaseById(request.TicketId);
        if (pointspurchase is null)
        {
            return Errors.Tickets.PurchaseNotFound;
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
        pointspurchase.Update(partner, ticket, request.TotalPoints);
        var res = await _pointsPurchaseRepository.Update(pointspurchase);
        return new GetPointsPurchaseResult(res);
    }
}
