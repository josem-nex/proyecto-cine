namespace Cine.Application.Models.Admins.Queries.Login;
using Cine.Application.Models.Admins.Queries.Get;
using ErrorOr;
using MediatR;

public record LoginAdminQuery(string User, string Password) : IRequest<ErrorOr<GetAdminResult>>;
