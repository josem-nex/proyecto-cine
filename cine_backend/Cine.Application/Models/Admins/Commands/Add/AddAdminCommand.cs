using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Admins.Commands;
public record AddAdminCommand(string User, string Password) : IRequest<ErrorOr<AddAdminResult>>;
