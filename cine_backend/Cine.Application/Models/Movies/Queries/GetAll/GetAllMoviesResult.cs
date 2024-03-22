using Cine.Domain.Entities.Movies;

namespace Cine.Application.Models.Movies.Queries.GetAll;
public record GetAllMoviesResult(List<Movie> Movies);