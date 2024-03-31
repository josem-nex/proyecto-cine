using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Queries.GetChairs;

public record GetChairsHallResult(List<int> ChairsId);
public record GetChairsHallRequest(int Id);
public record GetChairsHallQuery(int Id) : IRequest<ErrorOr<GetChairsHallResult>>;

public class GetChairsHallQueryHandler : IRequestHandler<GetChairsHallQuery, ErrorOr<GetChairsHallResult>>
{
    private readonly IHallRepository _hallRepository;

    public GetChairsHallQueryHandler(IHallRepository hallRepository)
    {
        _hallRepository = hallRepository;
    }

    public async Task<ErrorOr<GetChairsHallResult>> Handle(GetChairsHallQuery request, CancellationToken cancellationToken)
    {
        var hall = await _hallRepository.GetHallById(request.Id);
        if (hall is null)
        {
            return Errors.Hall.HallNotFound;
        }

        var chairsId = await _hallRepository.GetChairsId(request.Id);
        return new GetChairsHallResult(chairsId);
    }
}