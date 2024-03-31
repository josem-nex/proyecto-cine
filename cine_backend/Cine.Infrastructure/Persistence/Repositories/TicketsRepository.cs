using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class TicketsRepository : ITicketRepository
{
    private readonly CineDbContext _dbContext;

    public TicketsRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Ticket Ticket)
    {
        await _dbContext.Tickets.AddAsync(Ticket);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Ticket?> GetTicketById(int Id)
    {
        return await _dbContext.Tickets.SingleOrDefaultAsync(u => u.Id == Id);
    }

    public async Task Delete(Ticket Ticket)
    {
        _dbContext.Tickets.Remove(Ticket);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<Ticket>> GetTicketList()
    {
        return _dbContext.Tickets.AsNoTracking().ToListAsync();
    }

    public async Task<Ticket?> Update(Ticket Ticket)
    {
        _dbContext.Tickets.Update(Ticket);
        await _dbContext.SaveChangesAsync();
        return Ticket;
    }


}

