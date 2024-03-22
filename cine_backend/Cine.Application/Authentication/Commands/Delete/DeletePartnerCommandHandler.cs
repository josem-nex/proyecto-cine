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
        if (await _partnerRepository.GetPartnerByEmail(request.Email) is not Partner partner)
        {
            return Errors.Partner.EmailNotFound;
        }
        var hasher = new PasswordHasher<Partner>();
        var verificationResult = hasher.VerifyHashedPassword(partner, partner.Password, request.Password);
        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return Errors.Partner.InvalidPassword;
        }
        await _partnerRepository.Delete(request.Email);
        return Unit.Value;
    }
}
