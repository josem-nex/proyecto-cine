using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Cine.Application.Models.Halls.Queries;

namespace Cine.Application.Models.Halls.Commands;

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
