using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Countries.Queries.GetOne;
public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, ErrorOr<GetCountryResult>>
{
    private readonly ICountryRepository countryRepository;

    public GetCountryQueryHandler(ICountryRepository countryRepository)
    {
        this.countryRepository = countryRepository;
    }

    public async Task<ErrorOr<GetCountryResult>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
    {
        var country = await countryRepository.GetCountryById(request.CountryId);
        if (country is null)
        {
            return Errors.Movie.CountryNotFound;
        }
        return new GetCountryResult(country);
    }
}