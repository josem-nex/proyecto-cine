using ErrorOr;
using MediatR;

namespace Cine.Application.Models.ShowTimes;

public record DeleteShowTimeCommand(int Id) : IRequest<ErrorOr<Unit>>;
