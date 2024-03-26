using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Queries;

public record GetHallResponse(int Id, string Name, int Capacity);

public record GetHallResult(Hall Hall);
public record GetHallRequest(int Id);
public record GetHallQuery(int Id) : IRequest<ErrorOr<GetHallResult>>;
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

public record GetAllHallsResult(List<Hall> Halls);

public record GetAllHallsQuery : IRequest<ErrorOr<GetAllHallsResult>>;
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
