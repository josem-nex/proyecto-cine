namespace Cine.Domain.Entities.Tickets;
public class MonetaryPurchase
{
    public User User { get; private set; } = null!;
    public Ticket Tickets { get; private set; } = null!;
    public int TotalPrice { get; private set; }
    public string? CreditCard { get; private set; }
}