using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Tickets.Commands;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, ErrorOr<Unit>>
{
    private readonly ITicketRepository _TicketRepository;
    public DeleteTicketCommandHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var Ticket = await _TicketRepository.GetTicketById(request.Id);
        if (Ticket is null)
            return Errors.Tickets.TicketNotFound;
        await _TicketRepository.Delete(Ticket);
        return Unit.Value;
    }
}