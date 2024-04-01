using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Entities.Tickets;
using Cine.Domain.Common.Errors;

namespace Cine.Application.Models.MonetaryPurchases.Queries;
public record GetMonetaryPurchaseRequest(int TicketId);
