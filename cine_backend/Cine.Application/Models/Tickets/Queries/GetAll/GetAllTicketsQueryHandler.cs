using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Tickets.Queries;

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, ErrorOr<GetAllTicketsResult>>
{
    private readonly ITicketRepository _TicketRepository;
    public GetAllTicketsQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<ErrorOr<GetAllTicketsResult>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var Tickets = await _TicketRepository.GetTicketList();
        return new GetAllTicketsResult(Tickets);
    }
}