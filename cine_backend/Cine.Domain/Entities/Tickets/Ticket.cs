namespace Cine.Domain.Entities.Tickets;
public class Ticket
{
    public int Id { get; private set; }
    public ShowTime ShowTimes { get; private set; } = null!;
    public Chair Chairs { get; private set; } = null!;
    public List<Discount> Discounts { get; private set; } = null!;
    public bool IsWeb { get; private set; }
}