using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using Cine.Domain.Entities.Tickets;
using MediatR;

namespace Cine.Application.Models.ShowTimes;

public class GetAllShowTimesQueryHandler : IRequestHandler<GetAllShowTimesQuery, ErrorOr<GetAllShowTimesResult>>
{
    private readonly IShowTimeRepository _ShowTimeRepository;
    public GetAllShowTimesQueryHandler(IShowTimeRepository ShowTimeRepository)
    {
        _ShowTimeRepository = ShowTimeRepository;
    }
    public async Task<ErrorOr<GetAllShowTimesResult>> Handle(GetAllShowTimesQuery request, CancellationToken cancellationToken)
    {
        List<ShowTime> ShowTimes = await _ShowTimeRepository.GetShowTimeList();
        return new GetAllShowTimesResult(ShowTimes);
    }
}