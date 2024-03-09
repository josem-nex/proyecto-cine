namespace Cine.Domain.Entities.Tickets;
public class Hall
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public int Capacity { get; private set; }
    public List<Chair> Chairs { get; private set; } = null!;
    // public List<Schedule> Schedules { get; private set; } = null!;
}