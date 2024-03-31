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
    /* public async Task Update(Movie movie)
        {

            // Obtén todos los actores y géneros necesarios en una sola consulta
            var actorIds = movie.Actors.Select(a => a.Id).ToList();
            var genreIds = movie.Genres.Select(g => g.Id).ToList();
            var actors = await _dbContext.Actors.Where(a => actorIds.Contains(a.Id)).ToListAsync();
            var genres = await _dbContext.Genres.Where(g => genreIds.Contains(g.Id)).ToListAsync();

            // Obtén la película a actualizar
            var movieToUpdate = await _dbContext.Movies
                .Include(m => m.Actors)
                .Include(m => m.Genres)
                .Include(m => m.Country)
                .SingleOrDefaultAsync(m => m.Id == movie.Id);

            // Actualiza las propiedades de la película
            _dbContext.Entry(movieToUpdate).CurrentValues.SetValues(movie);

            // Actualiza las relaciones con actores y géneros
            movieToUpdate.Actors.Clear();
            movieToUpdate.Actors.AddRange(actors);
            movieToUpdate.Genres.Clear();
            movieToUpdate.Genres.AddRange(genres);

            await _dbContext.SaveChangesAsync(); */
    public async Task<Ticket?> Update(Ticket Ticket)
    {
        var discountIds = Ticket.Discounts.Select(d => d.Id).ToList();
        var discounts = await _dbContext.Discounts.Where(d => discountIds.Contains(d.Id)).ToListAsync();

        var TicketToUpdate = await _dbContext.Tickets
            .Include(t => t.Discounts)
            .SingleOrDefaultAsync(t => t.Id == Ticket.Id);

        _dbContext.Entry(TicketToUpdate).CurrentValues.SetValues(Ticket);

        TicketToUpdate.Discounts.Clear();
        TicketToUpdate.Discounts.AddRange(discounts);

        await _dbContext.SaveChangesAsync();
        return Ticket;
    }


}

