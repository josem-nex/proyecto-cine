using Cine.Domain.Entities;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IAdminRepository
{
    Task<Admin> Add(Admin Admin);
    Task<Admin> Update(Admin Admin);
    Task Delete(Guid Id);
    Task<Admin?> GetAdminById(Guid Id);
    Task<List<Admin>> GetAdminList();
}