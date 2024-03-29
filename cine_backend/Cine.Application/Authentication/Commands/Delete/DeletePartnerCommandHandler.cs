using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cine.Application.Authentication.Commands.Delete;
public class DeletePartnerCommandHandler : IRequestHandler<DeletePartnerCommand, ErrorOr<Unit>>
{
    private readonly IPartnerRepository _partnerRepository;

    public DeletePartnerCommandHandler(IPartnerRepository partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var partner = await _partnerRepository.GetPartnerById(request.Id);
        if (partner is null)
        {
            return Errors.Partner.PartnerNotFound;
        }
        await _partnerRepository.Delete(request.Id);
        return Unit.Value;
    }
}
