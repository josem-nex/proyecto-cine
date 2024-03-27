using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;
using MediatR;

namespace Cine.Application.Models.ShowTimes;

public class GetShowTimeQueryHandler : IRequestHandler<GetShowTimeQuery, ErrorOr<GetShowTimeResult>>
{
    private readonly IShowTimeRepository _ShowTimeRepository;
    public GetShowTimeQueryHandler(IShowTimeRepository ShowTimeRepository)
    {
        _ShowTimeRepository = ShowTimeRepository;
    }
    public async Task<ErrorOr<GetShowTimeResult>> Handle(GetShowTimeQuery request, CancellationToken cancellationToken)
    {
        ShowTime? ShowTime = await _ShowTimeRepository.GetShowTimeById(request.Id);
        if (ShowTime is null)
        {
            return Errors.ShowTime.ShowTimeNotFound;
        }
        return new GetShowTimeResult(ShowTime);
    }
}
