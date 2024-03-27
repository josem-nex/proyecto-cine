using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Schedules.Commands;

public record DeleteScheduleCommand(int Id) : IRequest<ErrorOr<Unit>>;
