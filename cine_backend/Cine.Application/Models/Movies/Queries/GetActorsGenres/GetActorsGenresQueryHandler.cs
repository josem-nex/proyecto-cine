using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Queries.GetActorsGenres;

public class GetActorsGenresQueryHandler : IRequestHandler<GetActorsGenresQuery, ErrorOr<GetActorsGenresResult>>
{
    private readonly IMovieRepository _movieRepository;

    public GetActorsGenresQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<ErrorOr<GetActorsGenresResult>> Handle(GetActorsGenresQuery request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetMovieById(request.Id);
        if (movie is null)
        {
            return Errors.Movie.MovieNotFound;
        }

        var actors = await _movieRepository.GetActorsByMovie(request.Id);
        var genres = await _movieRepository.GetGenresByMovie(request.Id);
        return new GetActorsGenresResult(actors, genres);
    }
}

