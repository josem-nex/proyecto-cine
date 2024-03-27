using ErrorOr;
namespace Cine.Domain.Common.Errors;
public static partial class Errors
{
    public static class ShowTime
    {
        public static Error ShowTimeNotFound => Error.NotFound(
         code: ErrorCode.ShowTimeNotFound,
         description: "ShowTime not found");
        public static Error ShowTimeAlreadyExists => Error.Conflict(
            code: ErrorCode.ShowTimeAlreadyExists,
            description: "ShowTime already exists");
        public static Error ShowTimeInvalid => Error.Validation(
            code: ErrorCode.ShowTimeInvalid,
            description: "Invalid ShowTime");
        public static Error NullValue(string field) => Error.Validation(
            code: ErrorCode.NullValue,
            description: $"Value for {field} cannot be null");
        public static Error Validation(string field, string message) => Error.Validation(
            code: ErrorCode.Validation,
            description: $"{field}: {message}");
    }
}