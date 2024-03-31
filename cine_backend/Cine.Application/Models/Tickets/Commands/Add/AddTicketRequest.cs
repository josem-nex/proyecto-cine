namespace Cine.Application.Models.Tickets.Commands;

public record AddTicketRequest(
    int ShowTimesId,
    int ChairsId,
    List<int> DiscountsIds,
    bool IsWeb);
