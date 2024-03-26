namespace Cine.Api.Common.Mapping;

using Cine.Api.Controllers;
using Cine.Application.Authentication.Commands.Register;
using Cine.Application.Authentication.Commands.Update;
using Cine.Application.Authentication.Common;
using Cine.Application.Authentication.Queries.GetAll;
using Cine.Application.Authentication.Querys.Login;
using Cine.Application.Models.Admins.Commands;
using Cine.Application.Models.Admins.Queries.Get;
using Cine.Application.Models.Admins.Queries.GetAll;
using Cine.Application.Models.Admins.Queries.Login;
using Cine.Application.Models.Countries.Commands.Add;
using Cine.Application.Models.Countries.Queries.GetAll;
using Cine.Application.Models.Countries.Queries.GetOne;
using Cine.Application.Models.Halls.Commands;
using Cine.Application.Models.Halls.Queries;
using Cine.Application.Models.Movies.Commands.AddMovie;
using Cine.Application.Models.Movies.Commands.UpdateMovie;
using Cine.Application.Models.Movies.Queries.GetAll;
using Cine.Application.Models.Movies.Queries.GetOne;
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

        config.NewConfig<AddAdminRequest, AddAdminCommand>();
        config.NewConfig<GetAdminResult, GetAdminResponse>()
            .Map(dest => dest, src => src.Admin);
        config.NewConfig<AddAdminResult, GetAdminResponse>()
            .Map(dest => dest, src => src.Admin);
        config.NewConfig<GetAdminRequest, GetAdminQuery>();
        config.NewConfig<GetAllAdminResult, GetAllAdminResult>()
            .ConstructUsing(src => new GetAllAdminResult(src.Admins));
        config.NewConfig<LoginAdminRequest, LoginAdminQuery>();




        config.NewConfig<GetAllMoviesResult, GetAllMoviesResult>()
            .ConstructUsing(src => new GetAllMoviesResult(src.Movies));
        config.NewConfig<AddMovieResult, AddMovieResponse>()
            .Map(dest => dest, src => src.Movie);
        config.NewConfig<GetMovieResult, GetMovieResponse>()
            .Map(dest => dest.Id, src => src.Movie.Id)
            .Map(dest => dest.Title, src => src.Movie.Title)
            .Map(dest => dest.Description, src => src.Movie.Description)
            .Map(dest => dest.Director, src => src.Movie.Director)
            .Map(dest => dest.ImageUrl, src => src.Movie.ImageUrl)
            .Map(dest => dest.DurationMinutes, src => src.Movie.DurationMinutes)
            .Map(dest => dest.ReleaseDate, src => src.Movie.ReleaseDate)
            .Map(dest => dest.Language, src => src.Movie.Language)
            .Map(dest => dest.Rating, src => src.Movie.Rating)
            // .Map(dest => dest.Country, src => src.Movie.Country)
            .Map(dest => dest.CountryId, src => src.Movie.CountryId);
        config.NewConfig<GetMovieRequest, GetMovieQuery>();
        config.NewConfig<UpdateMovieRequest, UpdateMovieCommand>();

        config.NewConfig<GetAllCountriesQuery, GetAllCountriesQuery>();
        config.NewConfig<GetAllCountriesResult, GetAllCountriesResult>()
            .ConstructUsing(src => new GetAllCountriesResult(src.Countries));

        config.NewConfig<AddCountryRequest, AddCountryCommand>();
        config.NewConfig<AddCountryResult, AddCountryResponse>()
            .Map(dest => dest, src => src.Country);
        config.NewConfig<GetCountryRequest, GetCountryQuery>();
        config.NewConfig<GetCountryResult, GetCountryResponse>()
            .Map(dest => dest, src => src.Country);

        config.NewConfig<AddHallRequest, AddHallCommand>();
        config.NewConfig<AddHallResult, AddHallResponse>()
            .Map(dest => dest, src => src.Hall);
        config.NewConfig<UpdateHallRequest, UpdateHallCommand>();
        config.NewConfig<GetHallRequest, GetHallQuery>();
        config.NewConfig<GetHallResult, GetHallResponse>()
            .Map(dest => dest, src => src.Hall);
        config.NewConfig<GetAllHallsResult, GetAllHallsResult>()
            .ConstructUsing(src => new GetAllHallsResult(src.Halls));
    }
}