using ErrorOr;
using MediatR;
namespace Cine.Application.Models.Schedules.Queries.GetAll;
public record GetAllSchedulesQuery() : IRequest<ErrorOr<GetAllSchedulesResult>>;
