using Cine.Application.Models.Genres;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Api.Controllers;

[Route("genres")]
public class GenreController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public GenreController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllGenres()
    {
        var query = new GetAllGenresQuery();
        ErrorOr<GetAllGenresResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<GetAllGenresResult>(result)),
            errors => Problem(errors)
        );
    }
    [HttpPost("get")]
    public async Task<IActionResult> GetGenre(GetGenreRequest request)
    {
        var query = _mapper.Map<GetGenreQuery>(request);
        ErrorOr<GetGenreResult> GenreResult = await _mediator.Send(query);
        return GenreResult.Match(
            GenreResult => Ok(_mapper.Map<GetGenreResponse>(GenreResult)),
            errors => Problem(errors)
        );
    }
}
