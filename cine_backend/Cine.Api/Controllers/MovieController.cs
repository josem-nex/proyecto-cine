using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using MapsterMapper;
using Cine.Application.Models.Movies.Commands.AddMovie;
using Cine.Application.Models.Movies.Queries.GetAll;
using Cine.Application.Models.Movies.Queries.GetOne;
using Cine.Application.Models.Movies.Commands.DeleteMovie;
using Cine.Application.Models.Movies.Commands.UpdateMovie;
using Cine.Application.Models.Movies.Queries.GetActorsGenres;
namespace Cine.Api.Controllers
{
    [Route("movies")]
    public class MovieController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public MovieController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllMovies()
        {
            var query = new GetAllMoviesQuery();
            ErrorOr<GetAllMoviesResult> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(_mapper.Map<GetAllMoviesResult>(result)),
                errors => Problem(errors)
            );
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddMovie(AddMovieRequest request)
        {
            var command = _mapper.Map<AddMovieCommand>(request);
            ErrorOr<AddMovieResult> movieResult = await _mediator.Send(command);
            return movieResult.Match(
                movieResult => Ok(_mapper.Map<AddMovieResponse>(movieResult)),
                errors => Problem(errors)
            );
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetMovie(GetMovieRequest request)
        {
            var query = _mapper.Map<GetMovieQuery>(request);
            ErrorOr<GetMovieResult> authResult = await _mediator.Send(query);
            return authResult.Match(
                authResult => Ok(_mapper.Map<GetMovieResponse>(authResult)),
                errors => Problem(errors)
            );
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteMovie(DeleteMovieRequest request)
        {
            var command = _mapper.Map<DeleteMovieCommand>(request);
            ErrorOr<Unit> result = await _mediator.Send(command);
            return result.Match(
                _ => Ok(),
                errors => Problem(errors)
            );
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateMovie(UpdateMovieRequest request)
        {
            var command = _mapper.Map<UpdateMovieCommand>(request);
            ErrorOr<GetMovieResult> result = await _mediator.Send(command);
            return result.Match(
                result => Ok(_mapper.Map<GetMovieResponse>(result)),
                errors => Problem(errors)
            );
        }
        [HttpPost("getactorsgenres")]
        public async Task<IActionResult> GetActorsGenres(GetActorsGenresRequest getActorsGenresRequest)
        {
            var query = _mapper.Map<GetActorsGenresQuery>(getActorsGenresRequest);
            ErrorOr<GetActorsGenresResult> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(_mapper.Map<GetActorsGenresResult>(result)),
                errors => Problem(errors)
            );
        }
    }

}