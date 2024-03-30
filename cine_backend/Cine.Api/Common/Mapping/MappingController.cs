namespace Cine.Api.Common.Mapping;

using Cine.Api.Controllers;
using Cine.Application.Authentication.Commands.Register;
using Cine.Application.Authentication.Commands.Update;
using Cine.Application.Authentication.Common;
using Cine.Application.Authentication.Queries.Get;
using Cine.Application.Authentication.Queries.GetAll;
using Cine.Application.Authentication.Querys.Login;
using Cine.Application.Models.Actors;
using Cine.Application.Models.Admins.Commands;
using Cine.Application.Models.Admins.Queries.Get;
using Cine.Application.Models.Admins.Queries.GetAll;
using Cine.Application.Models.Admins.Queries.Login;
using Cine.Application.Models.Chairs;
using Cine.Application.Models.Countries.Commands.Add;
using Cine.Application.Models.Countries.Queries.GetAll;
using Cine.Application.Models.Countries.Queries.GetOne;
using Cine.Application.Models.Discounts;
using Cine.Application.Models.Genres;
using Cine.Application.Models.Halls.Commands;
using Cine.Application.Models.Halls.Queries;
using Cine.Application.Models.Movies.Commands.AddMovie;
using Cine.Application.Models.Movies.Commands.UpdateMovie;
using Cine.Application.Models.Movies.Queries.GetActorsGenres;
using Cine.Application.Models.Movies.Queries.GetAll;
using Cine.Application.Models.Movies.Queries.GetOne;
using Cine.Application.Models.Schedules.Commands;
using Cine.Application.Models.Schedules.Queries.Get;
using Cine.Application.Models.Schedules.Queries.GetAll;
using Cine.Application.Models.ShowTimes;
using Cine.Contracts.Authentication;
using Mapster;


public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterPartnerCommand>();
        config.NewConfig<UpdatePartnerRequest, UpdatePartnerCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<GetPartnerByIdRequest, GetPartnerByIdQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.Partner);

        config.NewConfig<GetPartnerListResult, GetPartnerListResult>()
            .ConstructUsing(src => new GetPartnerListResult(src.Partners));
        config.NewConfig<GetAllAdminResult, GetAllAdminResult>()
            .ConstructUsing(src => new GetAllAdminResult(src.Admins));

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

        config.NewConfig<GetAllGenresQuery, GetAllGenresQuery>();
        config.NewConfig<GetAllGenresResult, GetAllGenresResult>()
            .ConstructUsing(src => new GetAllGenresResult(src.Genres));
        config.NewConfig<GetGenreRequest, GetGenreQuery>();
        config.NewConfig<GetGenreResult, GetGenreResponse>()
            .Map(dest => dest, src => src.Genre);

        config.NewConfig<GetAllActorsQuery, GetAllActorsQuery>();
        config.NewConfig<GetAllActorsResult, GetAllActorsResult>()
            .ConstructUsing(src => new GetAllActorsResult(src.Actors));
        config.NewConfig<GetActorRequest, GetActorQuery>();
        config.NewConfig<GetActorResult, GetActorResponse>()
            .Map(dest => dest, src => src.Actor);

        config.NewConfig<GetActorsGenresRequest, GetActorsGenresQuery>();
        config.NewConfig<GetActorsGenresResult, GetActorsGenresResult>()
            .ConstructUsing(src => new GetActorsGenresResult(src.Actors, src.Genres));


        config.NewConfig<GetAllChairsQuery, GetAllChairsQuery>();
        config.NewConfig<GetAllChairsResult, GetAllChairsResult>()
            .ConstructUsing(src => new GetAllChairsResult(src.Chairs));
        config.NewConfig<GetChairRequest, GetChairQuery>();
        config.NewConfig<GetChairResult, GetChairResponse>()
            .Map(dest => dest, src => src.Chair);

        config.NewConfig<GetAllDiscountsQuery, GetAllDiscountsQuery>();
        config.NewConfig<GetAllDiscountsResult, GetAllDiscountsResult>()
            .ConstructUsing(src => new GetAllDiscountsResult(src.Discounts));
        config.NewConfig<GetDiscountRequest, GetDiscountQuery>();
        config.NewConfig<GetDiscountResult, GetDiscountResponse>()
            .Map(dest => dest, src => src.Discount);

        config.NewConfig<AddHallRequest, AddHallCommand>();
        config.NewConfig<AddHallResult, AddHallResponse>()
            .Map(dest => dest, src => src.Hall);
        config.NewConfig<UpdateHallRequest, UpdateHallCommand>();
        config.NewConfig<GetHallRequest, GetHallQuery>();
        config.NewConfig<GetHallResult, GetHallResponse>()
            .Map(dest => dest, src => src.Hall);
        config.NewConfig<GetAllHallsResult, GetAllHallsResult>()
            .ConstructUsing(src => new GetAllHallsResult(src.Halls));


        config.NewConfig<GetAllSchedulesResult, GetAllSchedulesResult>()
            .ConstructUsing(src => new GetAllSchedulesResult(src.Schedules));
        config.NewConfig<AddScheduleRequest, AddScheduleCommand>();
        config.NewConfig<GetScheduleResult, GetScheduleResponse>()
            .Map(dest => dest, src => src.Schedule);
        config.NewConfig<GetScheduleRequest, GetScheduleQuery>();
        config.NewConfig<UpdateScheduleRequest, UpdateScheduleCommand>();
        config.NewConfig<DeleteScheduleRequest, DeleteScheduleCommand>();


        config.NewConfig<AddShowTimeRequest, AddShowTimeCommand>();
        config.NewConfig<GetShowTimeResult, GetShowTimeResponse>()
            .Map(dest => dest.Id, src => src.ShowTime.Id)
            .Map(dest => dest.HallsId, src => src.ShowTime.HallsId)
            .Map(dest => dest.SchedulesId, src => src.ShowTime.SchedulesId)
            .Map(dest => dest.Cost, src => src.ShowTime.Cost)
            .Map(dest => dest.CostPoints, src => src.ShowTime.CostPoints)
            .Map(dest => dest.MovieId, src => src.ShowTime.MovieId);
        config.NewConfig<GetShowTimeRequest, GetShowTimeQuery>();
        config.NewConfig<DeleteShowTimeRequest, DeleteShowTimeCommand>();
        config.NewConfig<GetAllShowTimesResult, GetAllShowTimesResult>()
            .ConstructUsing(src => new GetAllShowTimesResult(src.ShowTimes));
    }
}