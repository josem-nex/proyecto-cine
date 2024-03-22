using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Queries.GetAll;
public record GetAllMoviesQuery() : IRequest<ErrorOr<GetAllMoviesResult>>;