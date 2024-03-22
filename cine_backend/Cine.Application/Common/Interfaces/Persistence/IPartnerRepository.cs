using Cine.Domain.Entities;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IPartnerRepository
{
    Task Add(Partner partner);
    Task Update(Partner partner);
    Task Delete(string email);
    Task<Partner?> GetPartnerByEmail(string email);
    Task<Partner?> GetPartnerById(Guid id);
    Task<List<Partner>> GetPartnerList();
}
