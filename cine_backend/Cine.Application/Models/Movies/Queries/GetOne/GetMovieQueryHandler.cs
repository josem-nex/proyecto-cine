using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Queries.GetOne;
public partial class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, ErrorOr<GetMovieResult>>
{
    private readonly IMovieRepository _movieRepository;
    public GetMovieQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public async Task<ErrorOr<GetMovieResult>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetMovieById(request.MovieId);
        if (movie == null)
        {
            return Errors.Movie.MovieNotFound;
        }
        return new GetMovieResult(movie);
    }
}