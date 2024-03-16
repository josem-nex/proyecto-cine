using ErrorOr;

namespace Cine.Domain.Common.Errors;
public static partial class Errors
{
    public static class Movie
    {
        public static Error CountryNotFound => Error.NotFound(
            code: ErrorCode.CountryNotFound,
            description: "Country not found");
        public static Error MovieAlreadyExists => Error.Conflict(
            code: ErrorCode.MovieAlreadyExists,
            description: "Movie already exists");
    }
}