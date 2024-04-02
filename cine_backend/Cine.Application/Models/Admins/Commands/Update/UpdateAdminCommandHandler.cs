using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Common.Errors;
using Cine.Application.Models.Admins.Queries.GetAll;
using Cine.Domain.Entities;
using Cine.Application.Models.Admins.Queries.Get;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Cine.Application.Models.Admins.Commands;

public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, ErrorOr<GetAdminResult>>
{
    private readonly IAdminRepository _adminRepository;
    public UpdateAdminCommandHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    public async Task<ErrorOr<GetAdminResult>> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        Admin admin = await _adminRepository.GetAdminById(request.Id);
        if (admin is null)
            return Errors.Admin.AdminNotFound;
        var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
        if (!passwordRegex.IsMatch(request.Password))
            return Errors.Partner.InvalidPassword;

        var hasher = new PasswordHasher<Admin>();
        var hashedPassword = hasher.HashPassword(null, request.Password);

        admin.Update(request.User, hashedPassword);
        var result = await _adminRepository.Update(admin);
        return new GetAdminResult(result);
    }
}
