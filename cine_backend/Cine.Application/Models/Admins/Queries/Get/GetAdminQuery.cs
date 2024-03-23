using ErrorOr;
using MediatR;
namespace Cine.Application.Models.Admins.Queries.Get;
public record GetAdminQuery(Guid Id) : IRequest<ErrorOr<GetAdminResult>>;
