using Cine.Application.Authentication.Common;
using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cine.Application.Authentication.Querys.Login;
public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPartnerRepository _partnerRepository;
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IPartnerRepository partnerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _partnerRepository = partnerRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
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

        var token = _jwtTokenGenerator.GenerateToken(partner);

        return new AuthenticationResult(
            partner,
            token);
    }
}