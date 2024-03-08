using Cine.Domain.Entities;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void Add(User user);
    void Update(User user);
    void Delete(string email);
    User? GetUserByEmail(string email);
    List<User> GetUserList();
}