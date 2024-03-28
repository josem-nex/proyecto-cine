using Cine.Application.Models.Movies.Queries.GetOne;
using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Commands.UpdateMovie;

public record UpdateMovieCommand(
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
    int CountryId) : IRequest<ErrorOr<GetMovieResult>>;
