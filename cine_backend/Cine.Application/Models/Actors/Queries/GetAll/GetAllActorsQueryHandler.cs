using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Actors;

public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQuery, ErrorOr<GetAllActorsResult>>
{
    private readonly IActorRepository _actorRepository;
    public GetAllActorsQueryHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }
    public async Task<ErrorOr<GetAllActorsResult>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
    {
        var actors = await _actorRepository.GetActorList();
        return new GetAllActorsResult(actors);
    }
}