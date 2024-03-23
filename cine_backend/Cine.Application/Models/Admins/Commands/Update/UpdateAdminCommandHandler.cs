using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Common.Errors;
using Cine.Application.Models.Admins.Queries.GetAll;
using Cine.Domain.Entities;
using Cine.Application.Models.Admins.Queries.Get;

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
        admin.Update(request.User, request.Password);
        var result = await _adminRepository.Update(admin);
        return new GetAdminResult(result);
    }
}
