using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Queries.GetAll;

public class GetPartnerListQueryHandler :
    IRequestHandler<GetPartnerListQuery, ErrorOr<GetPartnerListResult>>
{
    private readonly IPartnerRepository _partnerRepository;
    public GetPartnerListQueryHandler(IPartnerRepository partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public async Task<ErrorOr<GetPartnerListResult>> Handle(GetPartnerListQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        List<Partner> partners = await _partnerRepository.GetPartnerList();
        return new GetPartnerListResult(partners);
    }
}