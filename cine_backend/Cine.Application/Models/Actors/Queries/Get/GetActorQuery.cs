using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Actors;

public record GetActorQuery(int Id) : IRequest<ErrorOr<GetActorResult>>;
