namespace Cine.Domain.Entities.Tickets;
public class PointsPurchase
{
    public Partner? User { get; private set; }
    public Guid UserId { get; private set; }
    public Ticket? Ticket { get; private set; }
    public int TicketId { get; private set; }
    public int TotalPoints { get; private set; }
    public PointsPurchase(Partner user, Ticket ticket, int totalPoints)
    {
        User = user;
        UserId = user.Id;
        Ticket = ticket;
        TicketId = ticket.Id;
        TotalPoints = totalPoints;
    }
    public PointsPurchase(Guid userId, int ticketId, int totalPoints)
    {
        UserId = userId;
        TicketId = ticketId;
        TotalPoints = totalPoints;
    }
    public void Update(Partner user, Ticket ticket, int totalPoints)
    {
        User = user;
        UserId = user.Id;
        Ticket = ticket;
        TicketId = ticket.Id;
        TotalPoints = totalPoints;
    }
}