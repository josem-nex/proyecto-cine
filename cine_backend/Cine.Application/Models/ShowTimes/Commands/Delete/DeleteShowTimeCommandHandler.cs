using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using MediatR;

namespace Cine.Application.Models.ShowTimes;

public class DeleteShowTimeCommandHandler : IRequestHandler<DeleteShowTimeCommand, ErrorOr<Unit>>
{
    private readonly IShowTimeRepository _ShowTimeRepository;
    public DeleteShowTimeCommandHandler(IShowTimeRepository ShowTimeRepository)
    {
        _ShowTimeRepository = ShowTimeRepository;
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteShowTimeCommand request, CancellationToken cancellationToken)
    {
        ShowTime? ShowTime = await _ShowTimeRepository.GetShowTimeById(request.Id);
        if (ShowTime is null)
        {
            return Errors.ShowTime.ShowTimeNotFound;
        }
        await _ShowTimeRepository.Delete(ShowTime);
        return Unit.Value;
    }
}
