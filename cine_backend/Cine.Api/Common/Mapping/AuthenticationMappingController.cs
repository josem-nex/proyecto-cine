namespace Cine.Api.Common.Mapping;

using Cine.Application.Authentication.Commands.Register;
using Cine.Application.Authentication.Common;
using Cine.Application.Authentication.Querys.Login;
using Cine.Contracts.Authentication;
using Mapster;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}