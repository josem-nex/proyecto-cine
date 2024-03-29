using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Chairs;

public class GetAllChairsQueryHandler : IRequestHandler<GetAllChairsQuery, ErrorOr<GetAllChairsResult>>
{
    private readonly IChairRepository _repository;
    public GetAllChairsQueryHandler(IChairRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<GetAllChairsResult>> Handle(GetAllChairsQuery request, CancellationToken cancellationToken)
    {
        var chairs = await _repository.GetChairList();
        return new GetAllChairsResult(chairs);
    }
}