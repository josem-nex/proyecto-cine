using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Countries.Queries.GetAll;

public record GetAllCountriesResult(List<Country> Countries) : IRequest<ErrorOr<GetAllCountriesResult>>
{
}
