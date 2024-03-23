namespace Cine.Application.Models.Admins.Queries.Login;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Models.Admins.Queries.Get;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;

public class LoginAdminQueryHandler : IRequestHandler<LoginAdminQuery, ErrorOr<GetAdminResult>>
{
    private readonly IAdminRepository _adminRepository;
    public LoginAdminQueryHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    public async Task<ErrorOr<GetAdminResult>> Handle(LoginAdminQuery request, CancellationToken cancellationToken)
    {
        var admin = await _adminRepository.GetAdminByUser(request.User);
        if (admin is null)
        {
            return Errors.Admin.AdminNotFound;
        }
        var hasher = new PasswordHasher<Admin>();
        var verificationResult = hasher.VerifyHashedPassword(admin, admin.Password, request.Password);
        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return Errors.Admin.InvalidPassword;
        }
        return new GetAdminResult(admin);
    }
}
