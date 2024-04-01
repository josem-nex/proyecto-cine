using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Models.PointsPurchases;

public record GetAllPointsPurchasesResult(List<PointsPurchase> PointsPurchases);
