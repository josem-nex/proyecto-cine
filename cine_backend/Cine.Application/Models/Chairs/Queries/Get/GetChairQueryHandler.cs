using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Chairs;

public class GetChairQueryHandler : IRequestHandler<GetChairQuery, ErrorOr<GetChairResult>>
{
    private readonly IChairRepository _repository;
    public GetChairQueryHandler(IChairRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<GetChairResult>> Handle(GetChairQuery request, CancellationToken cancellationToken)
    {
        var chair = await _repository.GetChairById(request.Id);
        if (chair is null)
            return Errors.Hall.ChairNotFound;


        return new GetChairResult(chair);
    }
}
