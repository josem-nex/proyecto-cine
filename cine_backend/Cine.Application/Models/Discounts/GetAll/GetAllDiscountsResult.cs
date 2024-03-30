using Cine.Domain.Entities.Tickets;

namespace Cine.Application.Models.Discounts;

public record GetAllDiscountsResult(List<Discount> Discounts);
