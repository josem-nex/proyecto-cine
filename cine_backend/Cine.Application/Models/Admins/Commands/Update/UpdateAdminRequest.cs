namespace Cine.Application.Models.Admins.Commands;

public record UpdateAdminRequest(Guid Id, string User, string Password);
