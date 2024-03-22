using Cine.Domain.Entities.Movies;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Countries.Commands.Add;

public record AddCountryCommand(string Name) : IRequest<ErrorOr<AddCountryResult>>;
