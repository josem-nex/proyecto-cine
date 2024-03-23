using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cine.Application.Models.Admins.Commands;

public class AddAdminCommandHandler : IRequestHandler<AddAdminCommand, ErrorOr<AddAdminResult>>
{
    private readonly IAdminRepository _adminRepository;
    public AddAdminCommandHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    public async Task<ErrorOr<AddAdminResult>> Handle(AddAdminCommand request, CancellationToken cancellationToken)
    {
        if (await _adminRepository.GetAdminByUser(request.User) is not null)
            return Errors.Admin.DuplicatedAdmin;
        var hasher = new PasswordHasher<Admin>();
        var hashedPassword = hasher.HashPassword(null, request.Password);
        var admin = new Admin(request.User, hashedPassword);
        await _adminRepository.Add(admin);
        return new AddAdminResult(admin);
    }
}
