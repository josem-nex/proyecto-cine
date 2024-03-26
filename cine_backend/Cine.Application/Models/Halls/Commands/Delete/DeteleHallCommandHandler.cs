using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Halls.Commands;

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
