using Cine.Application.Authentication.Common;
using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cine.Application.Authentication.Commands.Register;
public class RegisterPartnerCommandHandler :
    IRequestHandler<RegisterPartnerCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPartnerRepository _partnerRepository;
    public RegisterPartnerCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IPartnerRepository partnerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _partnerRepository = partnerRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterPartnerCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (await _partnerRepository.GetPartnerByEmail(command.Email) is not null)
        {
            return Errors.Partner.DuplicatedEmail;
        }
        var hasher = new PasswordHasher<Partner>();
        var hashedPassword = hasher.HashPassword(null, command.Password);
        var partner = new Partner(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Ci,
            command.Address,
            command.PhoneNumber,
            hashedPassword
        );
        await _partnerRepository.Add(partner);
        // Guid id = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(partner);

        return new AuthenticationResult(
            partner,
            token);
    }
}