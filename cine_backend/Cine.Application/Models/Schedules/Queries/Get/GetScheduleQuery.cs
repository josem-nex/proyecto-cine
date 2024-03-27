using ErrorOr;
using MediatR;
namespace Cine.Application.Models.Schedules.Queries.Get;

public record GetScheduleQuery(int Id) : IRequest<ErrorOr<GetScheduleResult>>;
