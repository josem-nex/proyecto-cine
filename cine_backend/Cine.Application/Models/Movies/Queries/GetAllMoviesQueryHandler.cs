namespace Cine.Application.Models.Movies.Queries;

using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, ErrorOr<GetAllMoviesResult>>
{
    private readonly IMovieRepository _movieRepository;

    public GetAllMoviesQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<ErrorOr<GetAllMoviesResult>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        List<Movie> movies = await _movieRepository.GetMovieList();
        return new GetAllMoviesResult(movies);
    }
}