namespace Cine.Api.Common.Mapping;

using Cine.Application.Authentication.Commands.Register;
using Cine.Application.Authentication.Common;
using Cine.Application.Authentication.Queries.GetAll;
using Cine.Application.Authentication.Querys.Login;
using Cine.Application.Models.Movies.Queries;
using Cine.Contracts.Authentication;
using Mapster;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterPartnerCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.Partner);
        config.NewConfig<GetPartnerListResult, GetPartnerListResult>()
            .ConstructUsing(src => new GetPartnerListResult(src.Partners));
        config.NewConfig<GetAllMoviesResult, GetAllMoviesResult>()
            .ConstructUsing(src => new GetAllMoviesResult(src.Movies));
    }
}