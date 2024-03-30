using Cine.Domain.Entities.Movies;

namespace Cine.Application.Models.Actors;

public record GetAllActorsResult(List<Actor> Actors);
