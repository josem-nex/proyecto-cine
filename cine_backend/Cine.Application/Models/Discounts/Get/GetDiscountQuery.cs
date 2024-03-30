using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Discounts;

public record GetDiscountQuery(int Id) : IRequest<ErrorOr<GetDiscountResult>>;
