using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Common.Interfaces.Persistence;
public interface ITicketRepository
{
    Task Add(Ticket Ticket);
    Task<Ticket?> GetTicketById(int Id);
    Task Delete(Ticket Ticket);
    Task<List<Ticket>> GetTicketList();
    Task<Ticket?> Update(Ticket Ticket);
}