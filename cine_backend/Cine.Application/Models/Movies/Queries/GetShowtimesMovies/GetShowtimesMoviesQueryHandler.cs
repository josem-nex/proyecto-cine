using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Common.Errors;

namespace Cine.Application.Models.Movies.Queries.GetShowtimesMovies;

public class GetShowtimesMoviesQueryHandler : IRequestHandler<GetShowtimesMoviesQuery, ErrorOr<GetShowtimesMoviesResult>>
{
    private readonly IMovieRepository _movieRepository;

    public GetShowtimesMoviesQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<ErrorOr<GetShowtimesMoviesResult>> Handle(GetShowtimesMoviesQuery request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetMovieById(request.Id);
        if (movie is null)
        {
            return Errors.Movie.MovieNotFound;
        }

        var showtimes = await _movieRepository.GetShowtimesByMovie(request.Id);
        return new GetShowtimesMoviesResult(showtimes);
    }
}