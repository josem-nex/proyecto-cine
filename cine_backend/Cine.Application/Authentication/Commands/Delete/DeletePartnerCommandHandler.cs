using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;

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
        if (await _partnerRepository.GetPartnerByEmail(request.Email) is not Partner Partner)
        {
            return Errors.Partner.EmailNotFound;
        }
        if (Partner.Password != request.Password)
        {
            return Errors.Partner.InvalidPassword;
        }
        await _partnerRepository.Delete(request.Email);
        return Unit.Value;
    }
}
