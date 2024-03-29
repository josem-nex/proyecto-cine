using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Genres;

public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, ErrorOr<GetAllGenresResult>>
{
    private readonly IGenreRepository _genreRepository;
    public GetAllGenresQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<ErrorOr<GetAllGenresResult>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await _genreRepository.GetGenreList();
        return new GetAllGenresResult(genres);
    }
}
