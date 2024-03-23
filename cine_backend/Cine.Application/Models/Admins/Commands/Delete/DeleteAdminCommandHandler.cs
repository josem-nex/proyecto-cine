using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Common.Errors;

namespace Cine.Application.Models.Admins.Commands;

public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, ErrorOr<Unit>>
{
    private readonly IAdminRepository _adminRepository;
    public DeleteAdminCommandHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        if (await _adminRepository.GetAdminById(request.Id) is null)
            return Errors.Admin.AdminNotFound;
        await _adminRepository.Delete(request.Id);
        return Unit.Value;
    }
}
