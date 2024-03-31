using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Models.Tickets.Queries;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities.Tickets;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Tickets.Commands;

public class AddTicketCommandHandler : IRequestHandler<AddTicketCommand, ErrorOr<GetTicketResult>>
{
    private readonly ITicketRepository _TicketRepository;
    private readonly IShowTimeRepository _showTimeRepository;
    private readonly IChairRepository _chairRepository;
    private readonly IHallRepository _hallRepository;
    public AddTicketCommandHandler(ITicketRepository TicketRepository, IChairRepository chairRepository, IShowTimeRepository showTimeRepository, IHallRepository hallRepository)
    {
        _TicketRepository = TicketRepository;
        _chairRepository = chairRepository;
        _showTimeRepository = showTimeRepository;
        _hallRepository = hallRepository;
    }
    public async Task<ErrorOr<GetTicketResult>> Handle(AddTicketCommand request, CancellationToken cancellationToken)
    {
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
        var chairShow = await _hallRepository.GetChairsId(showTime.HallsId);
        if (chairShow.Contains(request.ChairsId) == false)
        {
            return Errors.Tickets.InvalidChair;
        }
        var Ticket = new Ticket(showTime, request.ShowTimesId, chair, request.ChairsId, request.IsWeb);
        await _TicketRepository.Add(Ticket);
        return new GetTicketResult(Ticket);
    }
}
