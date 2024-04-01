namespace Cine.Domain.Entities.Tickets;
public class MonetaryPurchase
{
    public User? User { get; private set; }
    public Guid UserId { get; private set; }
    public Ticket? Ticket { get; private set; }
    public int TicketId { get; private set; }
    public int TotalPrice { get; private set; }
    public string? CreditCard { get; private set; }
    public MonetaryPurchase(Guid userId, int ticketId, int totalPrice, string creditCard)
    {
        // User = user;
        UserId = userId;
        // Ticket = ticket;
        TicketId = ticketId;
        TotalPrice = totalPrice;
        CreditCard = creditCard;
    }
    public void Update(Guid userId, int ticketId, int totalPrice, string creditCard)
    {
        // User = user;
        UserId = userId;
        // Ticket = ticket;
        TicketId = ticketId;
        TotalPrice = totalPrice;
        CreditCard = creditCard;
    }
}