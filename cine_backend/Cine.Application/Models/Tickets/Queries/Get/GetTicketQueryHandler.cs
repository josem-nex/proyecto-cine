using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Tickets.Queries;

public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, ErrorOr<GetTicketResult>>
{
    private readonly ITicketRepository _TicketRepository;
    public GetTicketQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<ErrorOr<GetTicketResult>> Handle(GetTicketQuery request, CancellationToken cancellationToken)
    {
        var Ticket = await _TicketRepository.GetTicketById(request.Id);
        if (Ticket is null)
            return Errors.Tickets.TicketNotFound;
        return new GetTicketResult(Ticket);
    }
}
