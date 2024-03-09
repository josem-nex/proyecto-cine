namespace Cine.Domain.Entities.Tickets;
public class Schedule
{
    public int Id { get; private set; }
    public DateTime DateStart { get; private set; }
    public DateTime DateEnd { get; private set; }
    // public List<Hall> Halls { get; private set; } = null!;
}