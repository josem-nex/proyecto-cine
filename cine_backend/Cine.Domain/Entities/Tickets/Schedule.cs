namespace Cine.Domain.Entities.Tickets;
public class Schedule
{
    public int Id { get; private set; }
    public DateTime DateStart { get; private set; }
    public DateTime DateEnd { get; private set; }
    public List<Hall> Halls { get; private set; } = new List<Hall>();
    public Schedule(DateTime dateStart, DateTime dateEnd)
    {
        DateStart = dateStart;
        DateEnd = dateEnd;
    }
    public void Update(DateTime dateStart, DateTime dateEnd)
    {
        DateStart = dateStart;
        DateEnd = dateEnd;
    }
}