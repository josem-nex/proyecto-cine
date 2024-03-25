namespace Cine.Domain.Entities.Tickets;
public class Discount
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public int Value { get; private set; }
    public List<Ticket> Tickets { get; private set; } = new List<Ticket>();
}