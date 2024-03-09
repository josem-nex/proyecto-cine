namespace Cine.Domain.Entities.Tickets;
public class Chair
{
    public int Id { get; private set; }
    public int Row { get; private set; }
    public int Column { get; private set; }
    public Hall Hall { get; private set; } = null!;
}