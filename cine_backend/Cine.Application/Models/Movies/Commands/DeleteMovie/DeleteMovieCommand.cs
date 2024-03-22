using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Commands.DeleteMovie;
public record DeleteMovieCommand(int Id) : IRequest<ErrorOr<Unit>>;
