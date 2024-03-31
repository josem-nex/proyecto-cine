namespace Cine.Application.Models.Tickets.Commands;

public record UpdateTicketRequest(int Id, int ShowTimesId, int ChairsId, bool IsWeb);
