using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Countries.Queries.GetAll;

public record GetAllCountriesQuery() : IRequest<ErrorOr<GetAllCountriesResult>>;