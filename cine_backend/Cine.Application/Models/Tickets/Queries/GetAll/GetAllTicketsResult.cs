using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Models.Tickets.Queries;

public record GetAllTicketsResult(List<Ticket> Tickets);
