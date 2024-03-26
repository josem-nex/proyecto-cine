namespace Cine.Domain.Common.Errors;
public class ErrorCode
{
    public const string DuplicatedEmail = "Auth.DuplicatedEmail";
    public const string EmailNotFound = "Auth.EmailNotFound";
    public const string InvalidPassword = "Auth.InvalidPassword";
    public const string NullValue = "Error.NullValue";
    public const string Validation = "Error.Validation";
    public const string CountryNotFound = "Error.CountryNotFound";
    public const string MovieAlreadyExists = "Error.MovieAlreadyExists";
    public const string PartnerNotFound = "Error.PartnerNotFound";
    public const string CountryAlreadyExists = "Error.CountryAlreadyExists";
    public const string MovieNotFound = "Error.MovieNotFound";
    public const string AdminNotFound = "Error.AdminNotFound";
    public const string DuplicatedAdmin = "Error.DuplicatedAdmin";
    public const string HallNotFound = "Error.HallNotFound";
    public const string DuplicatedHall = "Error.DuplicatedHall";
}