using System.Text.RegularExpressions;
using Cine.Application.Authentication.Common;
using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cine.Application.Authentication.Commands.Update;
public class UpdatePartnerCommandHandler :
    IRequestHandler<UpdatePartnerCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPartnerRepository _partnerRepository;
    public UpdatePartnerCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IPartnerRepository partnerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _partnerRepository = partnerRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(UpdatePartnerCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var partner = await _partnerRepository.GetPartnerById(Guid.Parse(command.Id));
        if (partner is null)
            return Errors.Partner.PartnerNotFound;
        var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
        if (!passwordRegex.IsMatch(command.Password))
            return Errors.Partner.InvalidPassword;
        var hasher = new PasswordHasher<Partner>();
        var hashedPassword = hasher.HashPassword(partner, command.Password);
        partner.Update(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Ci,
            command.Address,
            command.PhoneNumber,
            hashedPassword
        );

        await _partnerRepository.Update(partner);

        var token = _jwtTokenGenerator.GenerateToken(partner);

        return new AuthenticationResult(
            partner,
            token);
    }
}