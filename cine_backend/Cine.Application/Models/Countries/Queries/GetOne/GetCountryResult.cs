using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Countries.Queries.GetOne;

public record GetCountryResult(Country Country) : IRequest<ErrorOr<GetCountryResult>>;
