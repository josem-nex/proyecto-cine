using Cine.Application.Authentication.Common;
using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;
using ErrorOr;
using MediatR;

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

        //  Revisar que el correo no existe, o sea el usuario tiene que ser único a la hora de registrarse
        //  Generar un ID único, Crear el usuario y annadirlo a la BD
        //  Crear un JwT Token
        if (_partnerRepository.GetPartnerByEmail(command.Email) is not null)
        {
            return Errors.Partner.DuplicatedEmail;
        }
        var partner = new Partner(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Ci,
            command.Address,
            command.PhoneNumber,
            command.Password
        );
        _partnerRepository.Add(partner);
        // Guid id = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(partner);

        return new AuthenticationResult(
            partner,
            token);
    }
}