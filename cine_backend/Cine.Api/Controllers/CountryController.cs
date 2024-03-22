using Cine.Application.Models.Countries.Commands.Add;
using Cine.Application.Models.Countries.Queries.GetAll;
using Cine.Application.Models.Countries.Queries.GetOne;
using Cine.Domain.Entities.Movies;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Api.Controllers;

[Route("countries")]
public class CountryController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public CountryController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCountries()
    {
        var query = new GetAllCountriesQuery();
        ErrorOr<GetAllCountriesResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<GetAllCountriesResult>(result)),
            errors => Problem(errors)
        );
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddCountry(AddCountryRequest request)
    {
        var command = _mapper.Map<AddCountryCommand>(request);
        ErrorOr<AddCountryResult> countryResult = await _mediator.Send(command);
        return countryResult.Match(
            countryResult => Ok(_mapper.Map<AddCountryResponse>(countryResult)),
            errors => Problem(errors)
        );
    }
    [HttpGet("get")]
    public async Task<IActionResult> GetCountry(GetCountryRequest request)
    {
        var query = _mapper.Map<GetCountryQuery>(request);
        ErrorOr<GetCountryResult> countryResult = await _mediator.Send(query);
        return countryResult.Match(
            countryResult => Ok(_mapper.Map<GetCountryResponse>(countryResult)),
            errors => Problem(errors)
        );
    }
}
