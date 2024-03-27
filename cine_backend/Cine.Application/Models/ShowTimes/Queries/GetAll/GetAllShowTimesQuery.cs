using ErrorOr;
using MediatR;

namespace Cine.Application.Models.ShowTimes;

public record GetAllShowTimesQuery() : IRequest<ErrorOr<GetAllShowTimesResult>>;
