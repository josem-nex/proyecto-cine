using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities.Movies;
using Cine.Domain.Entities.Tickets;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Movies.Commands.AddMovie;
public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, ErrorOr<AddMovieResult>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly ICountryRepository _countryRepository;
    public AddMovieCommandHandler(IMovieRepository movieRepository, ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
        _movieRepository = movieRepository;
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
        var movie = new Movie(
            command.Title,
            command.Description,
            command.Director,
            command.ImageUrl,
            command.DurationMinutes,
            command.ReleaseDate,
            command.Language,
            command.Rating,
            command.CountryId);
        await _movieRepository.Add(movie);
        return new AddMovieResult(movie);
    }
}