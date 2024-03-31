using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Models.Tickets.Queries;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities.Tickets;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Tickets.Commands;

public class UpdateTicketCommnadHandler : IRequestHandler<UpdateTicketCommand, ErrorOr<GetTicketResult>>
{
    private readonly ITicketRepository _TicketRepository;
    private readonly IShowTimeRepository _showTimeRepository;
    private readonly IChairRepository _chairRepository;
    public UpdateTicketCommnadHandler(ITicketRepository TicketRepository, IChairRepository chairRepository, IShowTimeRepository showTimeRepository)
    {
        _TicketRepository = TicketRepository;
        _chairRepository = chairRepository;
        _showTimeRepository = showTimeRepository;
    }
    public async Task<ErrorOr<GetTicketResult>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var Ticket = await _TicketRepository.GetTicketById(request.Id);
        if (Ticket is null)
        {
            return Errors.Tickets.TicketNotFound;
        }
        var showTime = await _showTimeRepository.GetShowTimeById(request.ShowTimesId);
        if (showTime is null)
        {
            return Errors.ShowTime.ShowTimeNotFound;
        }
        var chair = await _chairRepository.GetChairById(request.ChairsId);
        if (chair is null)
        {
            return Errors.Hall.ChairNotFound;
        }
        Ticket.Update(showTime, request.ShowTimesId, chair, request.ChairsId, request.IsWeb);
        await _TicketRepository.Update(Ticket);
        return new GetTicketResult(Ticket);
    }
}
