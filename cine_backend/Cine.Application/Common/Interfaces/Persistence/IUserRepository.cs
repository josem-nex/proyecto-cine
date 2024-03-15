using Cine.Domain.Entities;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task Add(User user);
    Task Update(User user);
    Task Delete(string email);
    Task<User?> GetUserByEmail(string email);
    Task<List<User>> GetUserList();
}