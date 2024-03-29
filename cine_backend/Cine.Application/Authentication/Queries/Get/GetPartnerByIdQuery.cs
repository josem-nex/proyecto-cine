using Cine.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Queries.Get;

public record GetPartnerByIdQuery(Guid Id) : IRequest<ErrorOr<AuthenticationResult>>;
