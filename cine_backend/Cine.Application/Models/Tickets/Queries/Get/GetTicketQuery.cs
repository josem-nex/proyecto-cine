using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Tickets.Queries;

public record GetTicketQuery(int Id) : IRequest<ErrorOr<GetTicketResult>>;
