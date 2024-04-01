using ErrorOr;
using MediatR;

namespace Cine.Application.Models.PointsPurchases;

public record GetAllPointsPurchasesQuery() : IRequest<ErrorOr<GetAllPointsPurchasesResult>>;
