namespace Cine.Application.Authentication.Queries.GetAll;
using ErrorOr;
using MediatR;

public record GetPartnerListQuery() : IRequest<ErrorOr<GetPartnerListResult>>;