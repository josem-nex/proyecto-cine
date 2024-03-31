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
    private readonly IDiscountRepository _discountRepository;
    public AddTicketCommandHandler(ITicketRepository TicketRepository, IChairRepository chairRepository, IShowTimeRepository showTimeRepository, IHallRepository hallRepository, IDiscountRepository discountRepository)
    {
        _TicketRepository = TicketRepository;
        _chairRepository = chairRepository;
        _showTimeRepository = showTimeRepository;
        _hallRepository = hallRepository;
        _discountRepository = discountRepository;
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
        List<Discount> discounts = new();
        foreach (var discountId in request.DiscountsIds)
        {
            var discount = await _discountRepository.GetDiscountById(discountId);
            if (discount is null)
            {
                return Errors.Tickets.DiscountNotFound;
            }
            discounts.Add(discount);
        }
        var Ticket = new Ticket(showTime, request.ShowTimesId, chair, request.ChairsId, discounts, request.IsWeb);
        await _TicketRepository.Add(Ticket);
        return new GetTicketResult(Ticket);
    }
}
