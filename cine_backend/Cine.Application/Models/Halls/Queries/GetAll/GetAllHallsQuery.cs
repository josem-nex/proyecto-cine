using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Queries;

public record GetAllHallsQuery : IRequest<ErrorOr<GetAllHallsResult>>;
