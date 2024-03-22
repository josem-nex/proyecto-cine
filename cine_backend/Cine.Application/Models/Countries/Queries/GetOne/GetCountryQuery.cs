using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Countries.Queries.GetOne;

public record GetCountryQuery(int CountryId) : IRequest<ErrorOr<GetCountryResult>>;
