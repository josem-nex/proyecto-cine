using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, ErrorOr<Unit>>
{
    private readonly IMovieRepository _context;

    public DeleteMovieCommandHandler(IMovieRepository context)
    {
        _context = context;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.GetMovieById(request.Id);
        if (movie is null)
        {
            return Errors.Movie.MovieNotFound;
        }

        await _context.Delete(movie);

        return Unit.Value;
    }
}