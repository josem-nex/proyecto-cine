namespace Cine.Domain.Entities.Tickets;
public class PointsPurchase
{
    public Partner User { get; private set; } = null!;
    public Ticket Tickets { get; private set; } = null!;
    public int TotalPoints { get; private set; }
}