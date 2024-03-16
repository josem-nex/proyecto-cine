
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using MapsterMapper;
using Cine.Application.Models.Movies.Queries;
using Cine.Application.Models.Movies.Commands.AddMovie;
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
        [HttpGet("all")]
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
            System.Console.WriteLine("mediatorok");
            return movieResult.Match(
                movieResult => Ok(_mapper.Map<AddMovieResponse>(movieResult)),
                errors => Problem(errors)
            );
        }


        /* 
                [HttpGet("{movieId:int}")]
                public async Task<IActionResult> GetMovie(LoginRequest request)
                {
                    var query = _mapper.Map<LoginQuery>(request);
                    ErrorOr<MovieResult> authResult = await _mediator.Send(query);
                    return authResult.Match(
                        authResult => Ok(_mapper.Map<MovieResponse>(authResult)),
                        errors => Problem(errors)
                    );
                }
                [HttpPost("delete")]
                public async Task<IActionResult> DeletePartner(DeletePartnerRequest request)
                {
                    var command = _mapper.Map<DeletePartnerCommand>(request);
                    ErrorOr<Unit> result = await _mediator.Send(command);
                    return result.Match(
                        _ => Ok(),
                        errors => Problem(errors)
                    );
                } */
    }
}