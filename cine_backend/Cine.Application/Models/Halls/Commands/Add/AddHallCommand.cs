using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Commands;

public record AddHallCommand(string Name, int Capacity, List<int> SchedulesId) : IRequest<ErrorOr<AddHallResult>>;
