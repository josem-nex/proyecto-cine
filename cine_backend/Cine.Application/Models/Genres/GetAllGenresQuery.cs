using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Genres;

public record GetAllGenresQuery() : IRequest<ErrorOr<GetAllGenresResult>>;
