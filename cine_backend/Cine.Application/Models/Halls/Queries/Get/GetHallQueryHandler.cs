using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Queries;

public class GetHallQueryHandler : IRequestHandler<GetHallQuery, ErrorOr<GetHallResult>>
{
    private readonly IHallRepository _repository;
    public GetHallQueryHandler(IHallRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<GetHallResult>> Handle(GetHallQuery request, CancellationToken cancellationToken)
    {
        var hall = await _repository.GetHallById(request.Id);
        if (hall == null)
        {
            return Errors.Hall.HallNotFound;
        }
        return new GetHallResult(hall);
    }
}
