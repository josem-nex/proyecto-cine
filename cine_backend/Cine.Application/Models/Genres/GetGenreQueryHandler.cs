using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Genres;

public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, ErrorOr<GetGenreResult>>
{
    private readonly IGenreRepository _genreRepository;
    public GetGenreQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<ErrorOr<GetGenreResult>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetGenreById(request.Id);
        if (genre is null)
        {
            return Errors.Movie.GenreNotFound;
        }
        return new GetGenreResult(genre);
    }
}
