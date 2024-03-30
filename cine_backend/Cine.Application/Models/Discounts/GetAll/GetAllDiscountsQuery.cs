using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Discounts;

public record GetAllDiscountsQuery() : IRequest<ErrorOr<GetAllDiscountsResult>>;
