using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Queries;

public record GetHallQuery(int Id) : IRequest<ErrorOr<GetHallResult>>;
