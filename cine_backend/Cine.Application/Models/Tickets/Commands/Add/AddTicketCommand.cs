using Cine.Application.Models.Tickets.Queries;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Tickets.Commands;

public record AddTicketCommand(int ShowTimesId, int ChairsId, List<int> DiscountsIds, bool IsWeb) : IRequest<ErrorOr<GetTicketResult>>;
