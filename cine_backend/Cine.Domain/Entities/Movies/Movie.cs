using Cine.Domain.Entities.Tickets;
using ErrorOr;

namespace Cine.Domain.Entities.Movies;
public class Movie
{
    public int Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string Director { get; private set; } = null!;
    public string ImageUrl { get; private set; } = null!;
    public int DurationMinutes { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public string Language { get; private set; } = null!;
    public int Rating { get; private set; }
    public List<Actor> Actors { get; private set; } = new List<Actor>();
    public List<Genre> Genres { get; private set; } = new List<Genre>();
    public Country? Country { get; private set; }
    public int CountryId { get; private set; } // FK
    public List<ShowTime> ShowTimes { get; private set; } = new List<ShowTime>();
    public Movie(string title, string description, string director, string imageUrl, int durationMinutes, DateTime releaseDate, string language, int rating, int countryId)
    {
        Title = title;
        Description = description;
        Director = director;
        ImageUrl = imageUrl;
        DurationMinutes = durationMinutes;
        ReleaseDate = releaseDate;
        Language = language;
        Rating = rating;
        CountryId = countryId;
        // Las listas de Actores y Géneros se inicializan como vacías
    }
    public Movie(string title, string description, string director, string imageUrl, int durationMinutes, DateTime releaseDate, string language, int rating, List<Actor> actors, List<Genre> genres, int countryId, Country country)
    {
        Title = title;
        Description = description;
        Director = director;
        ImageUrl = imageUrl;
        DurationMinutes = durationMinutes;
        ReleaseDate = releaseDate;
        Language = language;
        Rating = rating;
        Actors = actors;
        Genres = genres;
        CountryId = countryId;
        Country = country;
        // Las listas de Actores y Géneros se inicializan como vacías
    }
    public void Update(string title, string description, string director, string imageUrl, int durationMinutes, DateTime releaseDate, string language, int rating, List<Actor> actors, List<Genre> genres, int countryId, Country country)
    {
        Title = title;
        Description = description;
        Director = director;
        ImageUrl = imageUrl;
        DurationMinutes = durationMinutes;
        ReleaseDate = releaseDate;
        Language = language;
        Rating = rating;
        Actors = actors;
        Genres = genres;
        CountryId = countryId;
        Country = country;
    }
}


