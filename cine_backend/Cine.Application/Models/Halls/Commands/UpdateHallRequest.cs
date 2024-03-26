using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Cine.Application.Models.Halls.Queries;

namespace Cine.Application.Models.Halls.Commands;
public record UpdateHallRequest(int Id, string Name, int Capacity);
public record UpdateHallCommand(int Id, string Name, int Capacity) : IRequest<ErrorOr<GetHallResult>>;
public class UpdateHallCommandHandler : IRequestHandler<UpdateHallCommand, ErrorOr<GetHallResult>>
{
    private readonly IHallRepository _repository;
    public UpdateHallCommandHandler(IHallRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<GetHallResult>> Handle(UpdateHallCommand request, CancellationToken cancellationToken)
    {
        var hall = await _repository.GetHallById(request.Id);
        if (hall == null)
        {
            return Errors.Hall.HallNotFound;
        }
        hall.Update(request.Name, request.Capacity);
        await _repository.Update(hall);
        return new GetHallResult(hall);
    }
}
public record DeleteHallRequest(int Id);
public record DeleteHallCommand(int Id) : IRequest<ErrorOr<Unit>>;
public class DeteleHallCommandHandler : IRequestHandler<DeleteHallCommand, ErrorOr<Unit>>
{
    private readonly IHallRepository _repository;
    public DeteleHallCommandHandler(IHallRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteHallCommand request, CancellationToken cancellationToken)
    {
        var hall = await _repository.GetHallById(request.Id);
        if (hall == null)
        {
            return Errors.Hall.HallNotFound;
        }
        await _repository.Delete(hall);
        return Unit.Value;
    }
}
public record AddHallResponse(int Id, string Name, int Capacity);

public record AddHallResult(Hall Hall);
public record AddHallRequest(string Name, int Capacity);
public record AddHallCommand(string Name, int Capacity) : IRequest<ErrorOr<AddHallResult>>;
public class AddHallCommandHandler : IRequestHandler<AddHallCommand, ErrorOr<AddHallResult>>
{
    private readonly IHallRepository _repository;
    public AddHallCommandHandler(IHallRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<AddHallResult>> Handle(AddHallCommand request, CancellationToken cancellationToken)
    {
        var halltest = await _repository.GetHallByName(request.Name);
        if (halltest != null)
        {
            return Errors.Hall.DuplicatedHall;
        }
        var hall = new Hall(request.Name, request.Capacity);
        await _repository.Add(hall);
        return new AddHallResult(hall);
    }
}
