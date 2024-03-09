using Cine.Domain.Entities.Tickets;

namespace Cine.Domain.Entities.Movies;
public class Movie
{
    public int Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string Director { get; private set; } = null!;
    public int DurationMinutes { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public string Language { get; private set; } = null!;
    public int Rating { get; private set; }
    public List<Actor> Actors { get; private set; } = null!;
    public List<Genre> Genres { get; private set; } = null!;
    public Country Country { get; private set; } = null!;
    public List<ShowTime> ShowTimes { get; private set; } = null!;
}