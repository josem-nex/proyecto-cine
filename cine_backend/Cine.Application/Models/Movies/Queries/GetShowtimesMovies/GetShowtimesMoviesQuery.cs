using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Queries.GetShowtimesMovies;

public record GetShowtimesMoviesQuery(int Id) : IRequest<ErrorOr<GetShowtimesMoviesResult>>;
