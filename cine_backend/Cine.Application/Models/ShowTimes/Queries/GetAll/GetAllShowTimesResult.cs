using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Models.ShowTimes;

public record GetAllShowTimesResult(List<ShowTime> ShowTimes);
