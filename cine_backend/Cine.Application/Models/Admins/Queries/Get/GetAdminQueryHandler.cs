using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using ErrorOr;
using MediatR;
namespace Cine.Application.Models.Admins.Queries.Get;

public class GetAdminQueryHandler : IRequestHandler<GetAdminQuery, ErrorOr<GetAdminResult>>
{
    private readonly IAdminRepository _adminRepository;
    public GetAdminQueryHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    public async Task<ErrorOr<GetAdminResult>> Handle(GetAdminQuery request, CancellationToken cancellationToken)
    {
        var admin = await _adminRepository.GetAdminById(request.Id);
        return admin is null
            ? Errors.Admin.AdminNotFound
            : new GetAdminResult(admin);
    }
}