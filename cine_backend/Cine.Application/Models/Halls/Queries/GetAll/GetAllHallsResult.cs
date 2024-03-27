using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Models.Halls.Queries;

public record GetAllHallsResult(List<Hall> Halls);
