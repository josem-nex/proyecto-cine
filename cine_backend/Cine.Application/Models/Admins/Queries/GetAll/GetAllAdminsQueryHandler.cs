using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Models.Admins.Queries.GetAll;

public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, ErrorOr<GetAllAdminResult>>
{
    private readonly IAdminRepository _adminRepository;
    public GetAllAdminsQueryHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    public async Task<ErrorOr<GetAllAdminResult>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
    {
        var admins = await _adminRepository.GetAdminList();
        return new GetAllAdminResult(admins);
    }
}
