using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Commands.AddMovie;
public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, ErrorOr<AddMovieResult>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IActorRepository _actorRepository;
    private readonly IGenreRepository _genreRepository;
    public AddMovieCommandHandler(IMovieRepository movieRepository, ICountryRepository countryRepository, IActorRepository actorRepository, IGenreRepository genreRepository)
    {
        _movieRepository = movieRepository;
        _countryRepository = countryRepository;
        _actorRepository = actorRepository;
        _genreRepository = genreRepository;
    }
    public async Task<ErrorOr<AddMovieResult>> Handle(AddMovieCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var country = await _countryRepository.GetCountryById(command.CountryId);
        if (country is null)
        {
            return Errors.Movie.CountryNotFound;
        }
        var ismovie = await _movieRepository.GetMovieByTitle(command.Title);
        if (ismovie is not null)
        {
            return Errors.Movie.MovieAlreadyExists;
        }
        List<Actor> actors = new();
        List<Genre> genres = new();
        foreach (var idActor in command.IdActors)
        {
            var actor = await _actorRepository.GetActorById(idActor);
            if (actor is null)
            {
                return Errors.Movie.ActorNotFound;
            }
            actors.Add(actor);
        }
        foreach (var idGenre in command.IdGenres)
        {
            var genre = await _genreRepository.GetGenreById(idGenre);
            if (genre is null)
            {
                return Errors.Movie.GenreNotFound;
            }
            genres.Add(genre);
        }
        var movie = new Movie(
            command.Title,
            command.Description,
            command.Director,
            command.ImageUrl,
            command.DurationMinutes,
            command.ReleaseDate,
            command.Language,
            command.Rating,
            actors,
            genres,
            command.CountryId,
            country);
        await _movieRepository.Add(movie);
        return new AddMovieResult(movie);
    }
}