using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Actors;

public record GetAllActorsQuery() : IRequest<ErrorOr<GetAllActorsResult>>;
