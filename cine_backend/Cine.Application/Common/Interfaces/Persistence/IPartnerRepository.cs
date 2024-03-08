using Cine.Domain.Entities;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IPartnerRepository
{
    void Add(Partner partner);
    void Update(Partner partner);
    void Delete(string email);
    Partner? GetPartnerByEmail(string email);
    List<Partner> GetPartnerList();
}