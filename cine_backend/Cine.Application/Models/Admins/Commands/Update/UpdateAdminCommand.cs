using Cine.Application.Models.Admins.Queries.Get;
using Cine.Application.Models.Admins.Queries.GetAll;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Admins.Commands;

public record UpdateAdminCommand(Guid Id, string User, string Password) : IRequest<ErrorOr<GetAdminResult>>;
