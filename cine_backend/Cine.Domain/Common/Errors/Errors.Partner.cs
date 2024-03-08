
using ErrorOr;

namespace Cine.Domain.Common.Errors;
public static partial class Errors
{
    public static class Partner
    {
        public static Error DuplicatedEmail => Error.Conflict(
            code: ErrorCode.DuplicatedEmail,
            description: "Email already in use");
        public static Error EmailNotFound => Error.NotFound(
            code: ErrorCode.EmailNotFound,
            description: "Email does not exist");
        public static Error InvalidPassword => Error.Validation(
            code: ErrorCode.InvalidPassword,
            description: "Invalid password");
        public static Error NullValue(string field) => Error.Validation(
            code: ErrorCode.NullValue,
            description: $"Value for {field} cannot be null");
        public static Error Validation(string field, string message) => Error.Validation(
            code: ErrorCode.Validation,
            description: $"{field}: {message}");
    }
}