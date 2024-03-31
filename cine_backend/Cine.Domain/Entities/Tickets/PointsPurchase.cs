namespace Cine.Domain.Entities.Tickets;
public class PointsPurchase
{
    public Partner? User { get; private set; }
    public Guid UserId { get; private set; }
    public Ticket? Tickets { get; private set; }
    public int TicketsId { get; private set; }
    public int TotalPoints { get; private set; }
}