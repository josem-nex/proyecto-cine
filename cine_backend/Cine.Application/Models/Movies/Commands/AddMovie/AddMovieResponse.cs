using Cine.Domain.Entities.Movies;

namespace Cine.Application.Models.Movies.Commands.AddMovie;
public record AddMovieResponse(
    int Id,
    string Title,
    string Description,
    string Director,
    int DurationMinutes,
    DateTime ReleaseDate,
    string Language,
    int Rating,
    Country Country
);