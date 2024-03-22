using Cine.Domain.Entities.Movies;
using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Models.Movies.Queries.GetOne;

public record GetMovieResponse(
    int Id,
    string Title,
    string Description,
    string Director,
    string ImageUrl,
    int DurationMinutes,
    DateTime ReleaseDate,
    string Language,
    int Rating,
    // Country Country,
    int CountryId
);
