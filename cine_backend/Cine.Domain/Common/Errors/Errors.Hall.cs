using ErrorOr;

namespace Cine.Domain.Common.Errors;
public static partial class Errors
{
    public static class Hall
    {
        public static Error HallNotFound => Error.NotFound(
            code: ErrorCode.HallNotFound,
            description: "Hall not found");
        public static Error DuplicatedHall => Error.Conflict(
            code: ErrorCode.DuplicatedHall,
            description: "Hall name already in use");
        public static Error NullValue(string field) => Error.Validation(
            code: ErrorCode.NullValue,
            description: $"Value for {field} cannot be null");
        public static Error Validation(string field, string message) => Error.Validation(
            code: ErrorCode.Validation,
            description: $"{field}: {message}");
        public static Error ChairNotFound => Error.NotFound(
            code: ErrorCode.ChairNotFound,
            description: "Chair not found");
    }
}