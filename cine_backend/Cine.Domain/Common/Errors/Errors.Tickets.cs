using ErrorOr;

namespace Cine.Domain.Common.Errors;
public static partial class Errors
{
    public static class Tickets
    {
        public static Error TicketNotFound => Error.NotFound(
            code: ErrorCode.TicketNotFound,
            description: "Ticket not found");
        public static Error DiscountNotFound => Error.NotFound(
            code: ErrorCode.DiscountNotFound,
            description: "Discount not found");
        public static Error NullValue(string field) => Error.Validation(
            code: ErrorCode.NullValue,
            description: $"Value for {field} cannot be null");
        public static Error Validation(string field, string message) => Error.Validation(
            code: ErrorCode.Validation,
            description: $"{field}: {message}");
        public static Error InvalidChair => Error.Validation(
            code: ErrorCode.InvalidChair,
            description: "Invalid chair");
    }
}