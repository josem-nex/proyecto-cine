using Cine.Domain.Entities.Movies;

namespace Cine.Domain.Entities.Tickets;
public class ShowTime
{
    public int Id { get; private set; }
    public Hall Halls { get; private set; } = null!;
    public Schedule Schedules { get; private set; } = null!;
    public int Cost { get; private set; }
    public int CostPoints { get; private set; }
    public Movie Movie { get; private set; } = null!;
}