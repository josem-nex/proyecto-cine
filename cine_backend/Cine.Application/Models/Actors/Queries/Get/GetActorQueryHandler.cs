using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Actors;

public class GetActorQueryHandler : IRequestHandler<GetActorQuery, ErrorOr<GetActorResult>>
{
    private readonly IActorRepository _actorRepository;
    public GetActorQueryHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }
    public async Task<ErrorOr<GetActorResult>> Handle(GetActorQuery request, CancellationToken cancellationToken)
    {
        var actor = await _actorRepository.GetActorById(request.Id);
        if (actor is null)
            return Errors.Movie.ActorNotFound;
        return new GetActorResult(actor);
    }
}
