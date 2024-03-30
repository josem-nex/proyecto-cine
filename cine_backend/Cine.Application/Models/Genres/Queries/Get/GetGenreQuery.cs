using ErrorOr;
using MediatR;
namespace Cine.Application.Models.Genres;

public record GetGenreQuery(int Id) : IRequest<ErrorOr<GetGenreResult>>;
