using Cine.Domain.Entities;

namespace Cine.Application.Common.Interfaces.Persistence;

public interface IUserRepository{
    User? GetUserByEmail(string email);
    void Add(User user);
}