namespace Cine.Contracts.Authentication;

public record DeletePartnerRequest(
    string Email,
    string Password);
