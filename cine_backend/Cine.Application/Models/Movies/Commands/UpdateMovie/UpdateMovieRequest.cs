namespace Cine.Application.Models.Movies.Commands.UpdateMovie;

public record UpdateMovieRequest(
    int Id,
    string Title,
    string Description,
    string Director,
    string ImageUrl,
    int DurationMinutes,
    DateTime ReleaseDate,
    string Language,
    int Rating,
    List<int> IdActors,
    List<int> IdGenres,
    int CountryId);
