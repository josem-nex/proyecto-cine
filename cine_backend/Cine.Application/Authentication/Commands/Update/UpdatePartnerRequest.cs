namespace Cine.Application.Authentication.Commands.Update;
public record UpdatePartnerRequest(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string Ci,
    string Address,
    string PhoneNumber,
    string Password
    );