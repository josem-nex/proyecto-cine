namespace Cine.Domain.Entities.Tickets;
public class MonetaryPurchase
{
    public User? User { get; private set; }
    public int UserId { get; private set; }
    public Ticket? Tickets { get; private set; }
    public int TicketsId { get; private set; }
    public int TotalPrice { get; private set; }
    public string? CreditCard { get; private set; }
}