using ErrorOr;
using MediatR;

namespace Cine.Application.Models.ShowTimes;

public record GetShowTimeQuery(int Id) : IRequest<ErrorOr<GetShowTimeResult>>;
