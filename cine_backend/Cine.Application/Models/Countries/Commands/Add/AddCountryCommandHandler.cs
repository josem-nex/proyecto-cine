using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Countries.Commands.Add;

public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand, ErrorOr<AddCountryResult>>
{
    private readonly ICountryRepository countryRepository;

    public AddCountryCommandHandler(ICountryRepository countryRepository)
    {
        this.countryRepository = countryRepository;
    }

    public async Task<ErrorOr<AddCountryResult>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
    {
        if (countryRepository.GetCountryByName(request.Name).Result is not null)
        {
            return Errors.Movie.CountryAlreadyExists;
        }
        var country = new Country(request.Name);
        var cy = await countryRepository.Add(country);
        return new AddCountryResult(cy);
    }
}