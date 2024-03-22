namespace Cine.Api.Common.Mapping;

using Cine.Application.Authentication.Commands.Register;
using Cine.Application.Authentication.Commands.Update;
using Cine.Application.Authentication.Common;
using Cine.Application.Authentication.Queries.GetAll;
using Cine.Application.Authentication.Querys.Login;
using Cine.Application.Models.Countries.Commands.Add;
using Cine.Application.Models.Countries.Queries.GetAll;
using Cine.Application.Models.Countries.Queries.GetOne;
using Cine.Application.Models.Movies.Commands.AddMovie;
using Cine.Application.Models.Movies.Queries;
using Cine.Contracts.Authentication;
using Mapster;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterPartnerCommand>();
        config.NewConfig<UpdatePartnerRequest, UpdatePartnerCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.Partner);

        config.NewConfig<GetPartnerListResult, GetPartnerListResult>()
            .ConstructUsing(src => new GetPartnerListResult(src.Partners));
        config.NewConfig<GetAllMoviesResult, GetAllMoviesResult>()
            .ConstructUsing(src => new GetAllMoviesResult(src.Movies));
        config.NewConfig<AddMovieResult, AddMovieResponse>()
            .Map(dest => dest, src => src.Movie);

        config.NewConfig<GetAllCountriesQuery, GetAllCountriesQuery>();
        config.NewConfig<GetAllCountriesResult, GetAllCountriesResult>()
            .ConstructUsing(src => new GetAllCountriesResult(src.Countries));

        config.NewConfig<AddCountryRequest, AddCountryCommand>();
        config.NewConfig<AddCountryResult, AddCountryResponse>()
            .Map(dest => dest, src => src.Country);
        config.NewConfig<GetCountryRequest, GetCountryQuery>();
        config.NewConfig<GetCountryResult, GetCountryResponse>()
            .Map(dest => dest, src => src.Country);
    }
}