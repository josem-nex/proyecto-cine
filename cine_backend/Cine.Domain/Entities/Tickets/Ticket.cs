namespace Cine.Domain.Entities.Tickets;
public class Ticket
{
    public int Id { get; private set; }
    public ShowTime? ShowTimes { get; private set; }
    public int ShowTimesId { get; private set; }
    public Chair? Chairs { get; private set; }
    public int ChairsId { get; private set; }
    public List<Discount> Discounts { get; private set; } = new List<Discount>();
    public bool IsWeb { get; private set; }
}