using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Commands;

public record DeleteHallCommand(int Id) : IRequest<ErrorOr<Unit>>;
