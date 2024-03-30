namespace Cine.Domain.Entities.Tickets;
public class ScheduleHall
{
    public int SchedulesId { get; private set; }
    public Schedule Schedules { get; private set; } = null!;
    public int HallsId { get; private set; }
    public Hall Halls { get; private set; } = null!;
    public ScheduleHall(int schedulesId, int hallsId)
    {
        SchedulesId = schedulesId;
        HallsId = hallsId;
    }
}