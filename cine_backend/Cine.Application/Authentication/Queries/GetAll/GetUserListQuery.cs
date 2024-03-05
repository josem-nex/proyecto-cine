namespace Cine.Application.Authentication.Queries.GetAll;
using ErrorOr;
using MediatR;

public record GetUserListQuery() : IRequest<ErrorOr<GetUserListResult>>;