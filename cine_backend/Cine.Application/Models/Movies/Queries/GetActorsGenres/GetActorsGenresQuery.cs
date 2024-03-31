using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Queries.GetActorsGenres;

public record GetActorsGenresQuery(int Id) : IRequest<ErrorOr<GetActorsGenresResult>>;

