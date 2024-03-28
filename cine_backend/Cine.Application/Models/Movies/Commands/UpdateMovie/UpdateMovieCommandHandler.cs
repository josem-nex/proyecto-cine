using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Models.Movies.Queries.GetOne;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, ErrorOr<GetMovieResult>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IActorRepository _actorRepository;
    private readonly IGenreRepository _genreRepository;
    public UpdateMovieCommandHandler(IMovieRepository movieRepository, ICountryRepository countryRepository, IActorRepository actorRepository, IGenreRepository genreRepository)
    {
        _movieRepository = movieRepository;
        _countryRepository = countryRepository;
        _actorRepository = actorRepository;
        _genreRepository = genreRepository;
    }
    public async Task<ErrorOr<GetMovieResult>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetCountryById(request.CountryId);
        if (country == null)
        {
            return Errors.Movie.CountryNotFound;
        }
        var movie = await _movieRepository.GetMovieById(request.Id);
        if (movie == null)
        {
            return Errors.Movie.MovieNotFound;
        }
        List<Actor> actors = new();
        List<Genre> genres = new();
        foreach (var idActor in request.IdActors)
        {
            var actor = await _actorRepository.GetActorById(idActor);
            if (actor == null)
            {
                return Errors.Movie.ActorNotFound;
            }
            actors.Add(actor);
        }
        foreach (var idGenre in request.IdGenres)
        {
            var genre = await _genreRepository.GetGenreById(idGenre);
            if (genre == null)
            {
                return Errors.Movie.GenreNotFound;
            }
            genres.Add(genre);
        }

        movie.Update(request.Title, request.Description, request.Director, request.ImageUrl, request.DurationMinutes, request.ReleaseDate, request.Language, request.Rating, actors, genres, request.CountryId, country);

        await _movieRepository.Update(movie);
        return new GetMovieResult(movie);
    }
}