using Cine.Domain.Entities.Movies;

namespace Cine.Application.Models.Movies.Queries.GetActorsGenres;

public record GetActorsGenresResult(List<int> Actors, List<int> Genres);

