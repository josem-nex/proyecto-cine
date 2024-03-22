using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Queries.GetOne;

public record GetMovieQuery(int MovieId) : IRequest<ErrorOr<GetMovieResult>>;
