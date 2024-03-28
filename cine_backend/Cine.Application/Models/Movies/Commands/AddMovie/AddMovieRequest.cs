namespace Cine.Application.Models.Movies.Commands.AddMovie;
public record AddMovieRequest(
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
    int CountryId
);