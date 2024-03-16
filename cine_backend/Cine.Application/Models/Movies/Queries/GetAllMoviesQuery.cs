using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Queries;
public record GetAllMoviesQuery() : IRequest<ErrorOr<GetAllMoviesResult>>;