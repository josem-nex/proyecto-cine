namespace Cine.Application.Models.Tickets.Commands;

public record AddTicketRequest(
    int ShowTimesId, 
    int ChairsId, 
    bool IsWeb);
