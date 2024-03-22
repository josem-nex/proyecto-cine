using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Queries.GetOne;

public record GetMovieResult(Movie Movie) : IRequest<ErrorOr<GetMovieResult>>;
