using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Queries;

public class GetAllHallsQueryHandler : IRequestHandler<GetAllHallsQuery, ErrorOr<GetAllHallsResult>>
{
    private readonly IHallRepository _repository;
    public GetAllHallsQueryHandler(IHallRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<GetAllHallsResult>> Handle(GetAllHallsQuery request, CancellationToken cancellationToken)
    {
        var halls = await _repository.GetHallList();
        return new GetAllHallsResult(halls);
    }
}
