using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Countries.Commands.Add;

public record AddCountryResult(Country Country);
