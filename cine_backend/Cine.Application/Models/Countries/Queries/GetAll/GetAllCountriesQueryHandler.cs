namespace Cine.Application.Models.Countries.Queries.GetAll;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, ErrorOr<GetAllCountriesResult>>
{
    private readonly ICountryRepository countryRepository;

    public GetAllCountriesQueryHandler(ICountryRepository countryRepository)
    {
        this.countryRepository = countryRepository;
    }

    public async Task<ErrorOr<GetAllCountriesResult>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await countryRepository.GetAllAsync();
        return new GetAllCountriesResult(countries);
    }
}