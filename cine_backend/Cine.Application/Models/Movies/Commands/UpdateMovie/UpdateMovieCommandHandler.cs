using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Models.Movies.Queries.GetOne;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, ErrorOr<GetMovieResult>>
{
    private readonly IMovieRepository _movieRepository;
    public UpdateMovieCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public async Task<ErrorOr<GetMovieResult>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetMovieById(request.Id);
        if (movie == null)
        {
            return Errors.Movie.MovieNotFound;
        }
        movie.Update(request.Title, request.Description, request.Director, request.ImageUrl, request.DurationMinutes, request.ReleaseDate, request.Language, request.Rating, request.CountryId);
        await _movieRepository.Update(movie);
        return new GetMovieResult(movie);
    }
}