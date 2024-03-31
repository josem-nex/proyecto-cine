using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Tickets.Queries;

public record GetAllTicketsQuery() : IRequest<ErrorOr<GetAllTicketsResult>>;
