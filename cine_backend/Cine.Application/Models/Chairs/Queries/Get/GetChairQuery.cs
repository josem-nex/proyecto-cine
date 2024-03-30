using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Chairs;

public record GetChairQuery(int Id) : IRequest<ErrorOr<GetChairResult>>;
