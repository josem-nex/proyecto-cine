using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Chairs;

public record GetAllChairsQuery() : IRequest<ErrorOr<GetAllChairsResult>>;
