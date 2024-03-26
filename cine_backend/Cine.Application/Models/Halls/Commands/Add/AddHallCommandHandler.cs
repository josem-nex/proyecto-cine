using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Commands;

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
