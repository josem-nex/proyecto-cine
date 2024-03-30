using ErrorOr;

namespace Cine.Domain.Common.Errors;
public static partial class Errors
{
    public static class Schedule
    {
        public static Error ScheduleNotFound => Error.NotFound(
            code: ErrorCode.ScheduleNotFound,
            description: "Schedule not found");
        public static Error ScheduleAlreadyExists => Error.Conflict(
            code: ErrorCode.ScheduleAlreadyExists,
            description: "Schedule already exists");
        public static Error ScheduleInvalid => Error.Validation(
            code: ErrorCode.ScheduleInvalid,
            description: "Invalid Schedule");
        public static Error NullValue(string field) => Error.Validation(
            code: ErrorCode.NullValue,
            description: $"Value for {field} cannot be null");
        public static Error Validation(string field, string message) => Error.Validation(
            code: ErrorCode.Validation,
            description: $"{field}: {message}");
    }
}