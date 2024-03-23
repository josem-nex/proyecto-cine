using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Admins.Queries.GetAll;

public record GetAllAdminsQuery() : IRequest<ErrorOr<GetAllAdminResult>>;

