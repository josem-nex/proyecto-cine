using Cine.Domain.Entities.Movies;

namespace Cine.Application.Models.Genres;

public record GetAllGenresResult(List<Genre> Genres);
