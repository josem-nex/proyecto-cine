using Cine.Application.Authentication.Common;
using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using Cine.Domain.Common.Errors;
using MediatR;
using Cine.Application.Common.Interfaces.Authentication;

namespace Cine.Application.Authentication.Queries.Get;

public class GetPartnerByIdQueryHandler : IRequestHandler<GetPartnerByIdQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IPartnerRepository _partnerRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public GetPartnerByIdQueryHandler(IPartnerRepository partnerRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _partnerRepository = partnerRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(GetPartnerByIdQuery request, CancellationToken cancellationToken)
    {
        var partner = await _partnerRepository.GetPartnerById(request.Id);
        if (partner is null)
        {
            return Errors.Partner.PartnerNotFound;
        }
        var token = _jwtTokenGenerator.GenerateToken(partner);

        return new AuthenticationResult(partner, token);
    }
}