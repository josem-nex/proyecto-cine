using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Commands;

public record AddHallCommand(string Name, int Capacity) : IRequest<ErrorOr<AddHallResult>>;
