using Cine.Domain.Entities.Movies;

namespace Cine.Application.Models.Movies.Queries;
public record GetAllMoviesResult(List<Movie> Movies);