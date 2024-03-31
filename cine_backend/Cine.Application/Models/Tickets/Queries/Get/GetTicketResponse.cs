namespace Cine.Application.Models.Tickets.Queries;

public record GetTicketResponse(int Id, int ShowTimesId, int ChairsId, bool IsWeb);
