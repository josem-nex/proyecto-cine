using ErrorOr;
using MediatR;

namespace Cine.Application.Models.MonetaryPurchases.Queries;

public record GetAllMonetaryPurchasesQuery() : IRequest<ErrorOr<GetAllMonetaryPurchasesResult>>;
