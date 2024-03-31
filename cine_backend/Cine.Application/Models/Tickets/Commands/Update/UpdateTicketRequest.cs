namespace Cine.Application.Models.Tickets.Commands;

public record UpdateTicketRequest(int Id, int ShowTimesId, int ChairsId, List<int> DiscountsIds, bool IsWeb);
