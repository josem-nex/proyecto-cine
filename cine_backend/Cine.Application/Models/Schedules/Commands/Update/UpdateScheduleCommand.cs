using Cine.Application.Models.Schedules.Queries.Get;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Schedules.Commands;
public record UpdateScheduleCommand(int Id, DateTime DateStart, DateTime DateEnd) : IRequest<ErrorOr<GetScheduleResult>>;
